using Atomus.Database;
using Atomus.Service;
using System.Threading.Tasks;

namespace Atomus.Page.Join.Controllers
{
    internal static class DefaultJoinController
    {
        internal static async Task<IResponse> SaveAsync(this ICore core, string EMAIL, string ACCESS_NUMBER, string NICKNAME)
        {
            IServiceDataSet serviceDataSet;

            serviceDataSet = new ServiceDataSet { ServiceName = core.GetAttribute("ServiceName") };
            serviceDataSet["JOIN"].ConnectionName = core.GetAttribute("DatabaseName");
            serviceDataSet["JOIN"].CommandText = core.GetAttribute("ProcedureJoin");
            serviceDataSet["JOIN"].AddParameter("@EMAIL", DbType.NVarChar, 100);
            serviceDataSet["JOIN"].AddParameter("@ACCESS_NUMBER", DbType.NVarChar, 4000);
            serviceDataSet["JOIN"].AddParameter("@NICKNAME", DbType.NVarChar, 50);
            serviceDataSet["JOIN"].AddParameter("@USER_ID", DbType.Decimal, 18);

            serviceDataSet["JOIN"].NewRow();
            serviceDataSet["JOIN"].SetValue("@EMAIL", EMAIL.EmptyToDBNullValue());
            serviceDataSet["JOIN"].SetValue("@ACCESS_NUMBER", ACCESS_NUMBER.EmptyToDBNullValue());
            serviceDataSet["JOIN"].SetValue("@NICKNAME", NICKNAME.EmptyToDBNullValue());

            return await core.ServiceRequestAsync(serviceDataSet);
        }

        internal static async Task<IResponse> SavePasswordChangeAsync(this ICore core, string EMAIL, string ACCESS_NUMBER, string NEW_ACCESS_NUMBER)
        {
            IServiceDataSet serviceDataSet;

            serviceDataSet = new ServiceDataSet { ServiceName = core.GetAttribute("ServiceName") };
            serviceDataSet["JOIN"].ConnectionName = core.GetAttribute("DatabaseName");
            serviceDataSet["JOIN"].CommandText = core.GetAttribute("ProcedurePasswordChange");
            serviceDataSet["JOIN"].AddParameter("@EMAIL", DbType.NVarChar, 100);
            serviceDataSet["JOIN"].AddParameter("@ACCESS_NUMBER", DbType.NVarChar, 4000);
            serviceDataSet["JOIN"].AddParameter("@NEW_ACCESS_NUMBER", DbType.NVarChar, 4000);
            serviceDataSet["JOIN"].AddParameter("@USER_ID", DbType.Decimal, 18);

            serviceDataSet["JOIN"].NewRow();
            serviceDataSet["JOIN"].SetValue("@EMAIL", EMAIL.EmptyToDBNullValue());
            serviceDataSet["JOIN"].SetValue("@ACCESS_NUMBER", ACCESS_NUMBER.EmptyToDBNullValue());
            serviceDataSet["JOIN"].SetValue("@NEW_ACCESS_NUMBER", NEW_ACCESS_NUMBER.EmptyToDBNullValue());

            return await core.ServiceRequestAsync(serviceDataSet);
        }
    }
}
