

function GetAllSect() {
    /*alert('Hola');*/
    $.ajax({
        url: "Section/GetAllSection",
        type: 'GET'

    }).done(function (resp) {
        /*alert('Hola');*/
        var cont = 1;
        if (resp.length != 0) {
            var cont = 1;
            var template = '';
            for (var i = 0; i < resp.length; i++) {


                template += `
                             <tr guardarId="${resp[i].idSection}">
                             <td>${cont}</td>
                             <td><a>${resp[i].sectionName}</a></td>
                             <td><a>${resp[i].detail}</a></td>
                             <td>
                              <button  class="btn btn-info" onclick ='ShowSection(this)' data-toggle="modal" data-target="#EditSection"><i class="fas fa-pencil-alt"></i></button>
                              <button type="reset" class="btn btn-danger"  onclick='DeleteSection(this)'><i class="fas fa-trash-alt"></i></button>
                             </td>

                             `
                cont++;
            }
            $('#Tabla-Section').html(template);

        }

    })

}


function ShowSection(t) {

    var td = t.parentNode;
    var tr = td.parentNode;
    /*alert('Hola');*/
    var id = $(tr).attr('guardarId');
    /*alert(id);*/

    $.ajax({
        url: "Section/GetSection",
        type: 'POST',
        data: {
            idsection: id
        },
    }).done(function (resp) {
        $("#IdSection").val(resp.idSection);
        $("#EditName").val(resp.sectionName);
        $("#EditDetail").val(resp.detail);

    })
}


function Update_Section() {
    $.ajax({
        url: "Section/Edit",
        type: "POST",
        data: {
            idSection: $("#IdSection").val(),
            sectionName: $("#EditName").val(),
            detail: $("#EditDetail").val()
        },

    }).done(function (resp) {
        swal({
            type: "success",
            title: "La sección se registró correctamente",
            showConfirmButton: true,
            confirmButtonText: "Cerrar",
            closeOnConfirm: false
        })
            .then(function (result) {
                if (result.value) {
                    window.location = "Section";
                }
            })
    })
}


function DeleteSection(t) {

    swal({
        title: '¿Está seguro de borrar la sección?',
        text: "¡Si no lo está puede cancelar la acción!",
        type: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        cancelButtonText: 'Cancelar',
        confirmButtonText: 'Si!'
    }).then(function (result) {
        if (result.value) {
            var td = t.parentNode;
            var tr = td.parentNode;
            var IdSection = $(tr).attr('guardarId');
            console.log(IdSection);
            $.ajax({
                url: "Section/Delete",
                type: 'POST',
                data: {
                    id: IdSection
                },
            }).done(function (resp) {

                window.location = "Section";

            })

        }
    })
}



