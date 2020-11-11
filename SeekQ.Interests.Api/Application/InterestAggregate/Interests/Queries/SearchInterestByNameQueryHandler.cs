using App.Common.SeedWork;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.Interests.Api.Application.InterestAggregate.Interests.Queries
{
    public class SearchInterestByNameQueryHandler
    {
        public class Query : IRequest<IEnumerable<SearchInterestByNameViewModel>>
        {
            public Query(string interestName)
            {
                InterestName = interestName;
            }

            public string InterestName { get; set; }
        }

        public class Handler : IRequestHandler<Query, IEnumerable<SearchInterestByNameViewModel>>
        {
            private CommonGlobalAppSingleSettings _commonGlobalAppSingleSettings;

            public Handler(CommonGlobalAppSingleSettings commonGlobalAppSingleSettings)
            {
                _commonGlobalAppSingleSettings = commonGlobalAppSingleSettings;
            }

            public async Task<IEnumerable<SearchInterestByNameViewModel>> Handle(
                Query query,
                CancellationToken cancellationToken)
            {
                using (IDbConnection conn = new SqlConnection(_commonGlobalAppSingleSettings.MssqlConnectionString))
                {
                    string sql =
                        @"
                        SELECT 
	                        t.Id as interestsId, t.Name as interestName, t.PeopleCount as peopleCount
                        FROM 
	                        Interest t
		                WHERE t.Name LIKE '%@Name%'
                        ORDER BY t.Id ASC
                        LIMIT 7";

                    var result = await conn.QueryAsync<SearchInterestByNameViewModel>(sql, new { Name = query.InterestName });

                    return result;
                }
            }
        }
    }
}
