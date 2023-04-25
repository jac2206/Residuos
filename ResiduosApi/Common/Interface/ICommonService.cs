using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResiduosApi.Common.Interface
{
    public interface ICommonService
    {
        Task<List<Object>> ObtenerPartner();
        Task<Object> EventoPartner(object partner);
    }
}
