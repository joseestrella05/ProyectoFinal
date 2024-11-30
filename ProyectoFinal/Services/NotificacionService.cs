using BlazorBootstrap;

namespace ProyectoFinal.Services;

public class NotificacionService(ToastService toastService)
{
    public ToastMessage ShowToast(ToastType toastType, string message)
    {
        var mensaje = new ToastMessage()
        {
            Type = toastType,
            Message = $"{message}. El {DateTime.Now.ToString("dd/MM/yyyy")} a las {DateTime.Now.ToString("hh:mm tt")}",
        };
        toastService.Notify(mensaje);
        return mensaje;
    }
}
