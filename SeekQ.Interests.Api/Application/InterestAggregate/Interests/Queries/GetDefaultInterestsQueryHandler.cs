using App.Common.SeedWork;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using SeekQ.Interests.Api.Domain.InterestAggregate;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.Interests.Api.Application.InterestAggregate.Interests.Queries
{
    public class GetDefaultInterestsQueryHandler
    {
        public class Query : IRequest<GetDefaultInterestsViewModel>
        {
            public Query()
            {
            }
        }

        public class Handler : IRequestHandler<Query, GetDefaultInterestsViewModel>
        {
            private CommonGlobalAppSingleSettings _commonGlobalAppSingleSettings;

            public Handler(CommonGlobalAppSingleSettings commonGlobalAppSingleSettings)
            {
                _commonGlobalAppSingleSettings = commonGlobalAppSingleSettings;
            }

            public async Task<GetDefaultInterestsViewModel> Handle(
                Query query,
                CancellationToken cancellationToken)
            {
                using (IDbConnection conn = new SqlConnection(_commonGlobalAppSingleSettings.MssqlConnectionString))
                {
                    string sql =
                        @"
                        SELECT 
	                        t.Id as interestsId, t.Name as interestName
                        FROM 
	                        Interest t
                        ORDER BY t.Id ASC";

                    var defaultInterests = new GetDefaultInterestsViewModel();

                    var result = await conn.QueryAsync<GetDefaultInterestsViewModel, Interest, GetDefaultInterestsViewModel>(sql, (t, i) =>
                    {
                        if(i.Visibility == 0) 
                        {
                            defaultInterests.DefaultPublicInterests.Append(i);
                        } 
                        else if (i.Visibility == 1)
                        {
                            defaultInterests.DefaultPrivateInterests.Append(i);
                        }

                        return t;
                    });

                    return (GetDefaultInterestsViewModel)result;
                }
            }
        }
    }
}
