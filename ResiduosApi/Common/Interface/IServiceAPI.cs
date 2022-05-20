using ResiduosApi.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResiduosApi.Common.Interface
{
    public interface IServiceAPI
    {

        Task<List<DataInput>> ObtenerResiduos();
        Task<List<DataInput>> ObtenerResiduosXCiudad(string ciudad);

    }
}
