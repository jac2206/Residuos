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
        Task<Object> ObtenerUsuariosPCO();
        Task<List<DataInput>> ObtenerResiduosXCiudad(string ciudad);
        Task<EventSend> EnviarEvento(EventSend evento);
        Task<EventoWebHook> EnviarEventoHook(EventoWebHook evento);

    }
}
