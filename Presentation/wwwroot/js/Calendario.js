function fecha(fechaSelec) {

    if (fechaSelec != null) {
        var f = new Date(fechaSelec);
        var options = { year: 'numeric', month: 'numeric', day: 'numeric' };
        var selectFecha = (f.toLocaleDateString("es-ES", options));
        return selectFecha;

    } else {
        
        return '';
    }
   
}



function ListarCalendario() {

    $.ajax({

        url: "Calendario/ListarCalendario",
        type:'GET'
 
    }).done(function (resp) {

        if (resp.length >=0) {

            var template = '';
            var Bienvenida = '';

            for (var i = 0; i < resp.length; i++) {


                 template += `
                             <tr guardarId="${resp[i].id}">
                             <td>${i + 1}</td>
                             <td>${fecha(resp[i].fechaInicial)}</td>
                             <td>${fecha(resp[i].fechaFinal)}</td>
                             <td class="text-left align-middle">${(resp[i].detalle)}</td>
                             <td style="text-align:center;" tabindex="0" class="sorting_1">
                             <button style="color:white; padding: 2px 5px; font-size: 12px; line-height: 1.5; border-radius: 3px;" class="btn btn-danger">Editar</button>
                             <button style="color:white; padding: 2px 5px; font-size: 12px; line-height: 1.5; border-radius: 3px;" class="btn btn-primary">Eliminar</button>
                             </td>

                             `
                 }

            $("#contenido").html(template);
        }
    })
    
}