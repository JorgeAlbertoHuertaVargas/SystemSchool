function fechaMes(fechaSelec) {

    if (fechaSelec != null) {
        var f = new Date(fechaSelec);
        var options = { month: 'long'};
        var selectFecha = (f.toLocaleDateString("es-ES", options));
        return selectFecha;

    } else {

        return '';
    }

}
function fechaDia(fechaSelec) {

    if (fechaSelec != null) {
        var f = new Date(fechaSelec);
        var options = {day: 'numeric' };
        var selectFecha = (f.toLocaleDateString("es-ES", options));
        return selectFecha;

    } else {

        return '';
    }

}
function fechaAño(fechaSelec) {

    if (fechaSelec != null) {
        var f = new Date(fechaSelec);
        var options = { year: 'numeric' };
        var selectFecha = (f.toLocaleDateString("es-ES", options));
        return selectFecha;

    } else {

        return '';
    }

}



function ListarCalendarioBienvenida() {

    $.ajax({

        url: "Bienvenido/ListarCalendario",
        type: 'GET'

    }).done(function (resp) {

        console.log(resp);

        if (resp.length >= 0) {

            var template = '';

            for (var i = 0; i < resp.length; i++) {


                template += `
                             <tr class="event-future">

                                        <td class="text-center align-middle" scope="row">
                                            <div class="box-fecha">
                                                <div class="bf-mes opacity-75" style="font-size: 10pt;">${fechaMes(resp[i].fechaInicial)}</div>
                                                <div class="bf-dia " style="color:Orange;font-size:14pt;">
                                                    ${fechaDia(resp[i].fechaInicial)}
                                                </div>
                                                <div class="bf-ano opacity-75" style="font-size: 10pt;">${fechaAño(resp[i].fechaInicial)}</div>
                                            </div>
                                        </td>

                                        <td class="text-center align-middle">
                                            <div class="box-fecha">
                                                <div class="bf-mes opacity-75" style="font-size: 10pt;">${fechaMes(resp[i].fechaFinal)}</div>
                                                <div class="bf-dia" style="color:Orange;font-size:14pt;">
                                                    ${fechaDia(resp[i].fechaFinal)}
                                                </div>
                                                <div class="bf-ano opacity-75" style="font-size: 10pt;">${fechaAño(resp[i].fechaFinal)}</div>
                                            </div>
                                        </td>
                                        <td class="text-left align-middle">
                                            ${resp[i].detalle}
                                          </td>

                             `
            }

            $("#contenido").html(template);
        }
    })

}