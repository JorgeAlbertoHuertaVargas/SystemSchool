using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Extensions
{
    public class BaseController : Controller
    {
        public enum NotificationType
        {
            Success,
            Error,
            Info,
            warning
        }

        public void BasicNotification(string msj, NotificationType type, string title = "")
        {
            TempData["notification"] = $"Swal.fire('{title}','{msj}', '{type.ToString().ToLower()}')";
        }

        //public bool DeletedNotification(NotificationType type)
        //{
        //    TempData["notification"] = $"Swal.fire({
        //    title}: 'Are you sure?',
        //      text: "You won't be able to revert this!",
        //      icon: 'warning',
        //      showCancelButton: true,
        //      confirmButtonColor: '#3085d6',
        //      cancelButtonColor: '#d33',
        //      confirmButtonText: 'Yes, delete it!'
        //    }).then((result) => {
        //        if (result.isConfirmed)
        //        {
        //            Swal.fire(
        //              'Deleted!',
        //              'Your file has been deleted.',
        //              'success'
        //            )}
        //    })";

        //}
    }
}