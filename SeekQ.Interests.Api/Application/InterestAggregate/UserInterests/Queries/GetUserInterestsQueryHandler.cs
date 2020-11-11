using App.Common.SeedWork;
using Dapper;
using MediatR;
using Microsoft.Data.SqlClient;
using SeekQ.Interests.Api.Domain.InterestAggregate;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SeekQ.Interests.Api.Application.InterestAggregate.UserInterests.Queries
{
    public class GetUserInterestsQueryHandler
    {
        public class Query : IRequest<GetUserInterestsViewModel>
        {
            public Query(Guid idUser)
            {
                IdUser = idUser;
            }

            public Guid IdUser { get; set; }
        }

        public class Handler : IRequestHandler<Query, GetUserInterestsViewModel>
        {
            private CommonGlobalAppSingleSettings _commonGlobalAppSingleSettings;

            public Handler(CommonGlobalAppSingleSettings commonGlobalAppSingleSettings)
            {
                _commonGlobalAppSingleSettings = commonGlobalAppSingleSettings;
            }

            public async Task<GetUserInterestsViewModel> Handle(
                Query query,
                CancellationToken cancellationToken)
            {
                using (IDbConnection conn = new SqlConnection(_commonGlobalAppSingleSettings.MssqlConnectionString))
                {
                    string sql =
                        @"
                        SELECT 
	                        u.Id as userInterestsId, t.Name as interestName
                        FROM 
	                        UserInterests u
                            LEFT JOIN Interests t ON u.IdInterest = t.Id
		                WHERE u.IdUser = @IdUser";

                    var userInterests = new GetUserInterestsViewModel();

                    var result = await conn.QueryAsync<GetUserInterestsViewModel, Interest, GetUserInterestsViewModel>(sql, (t, i) =>
                    {
                        if (i.Visibility == 0)
                        {
                            userInterests.DefaultPublicInterests.Append(i);
                        }
                        else if (i.Visibility == 1)
                        {
                            userInterests.DefaultPrivateInterests.Append(i);
                        }

                        return t;
                    }, new { IdUser = query.IdUser });

                    return (GetUserInterestsViewModel)result;
                }
            }
        }
    }
}
