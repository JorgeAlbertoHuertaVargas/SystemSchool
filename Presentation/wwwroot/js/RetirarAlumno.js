function fechaCreate() {
    var f = new Date();
    DateCreated.value = f.getFullYear() + "-" + (f.getMonth() + 1) + "-" + f.getDate() + "  " + f.getHours() + ":" + f.getMinutes() + ":" + f.getSeconds();
}


$(".retirar").on("click", function () {
    var ids_array = [];
    $("input:checkbox[class=input_estudiantes]:checked").each(function () {

        ids_array.push($(this).val());

        if (ids_array.length>0) {

            $.ajax({
                url: "GetAlumnoById",
                data: {
                    id: ids_array
                },
                type: 'POST',
            }).done(function (resp) {
                fechaCreate();

                $("#nombreAlumno").val(resp["nombres"]);
                $("#idAlumno").val(resp["idAlumno"]);
                $("#codigoAlumno").val(resp["codigo"]);
                $("#apellidoeAlumno").val(resp["apellidos"]);
                $("#correolumno").val(resp["correo"]);
                $("#id_Usuario").val(resp["idUsers"]);
                $("#id_gradoAlumno").val(resp["idDegrees"]);
                $("#id_seccionAlumno").val(resp["idSections"]);
                $("#id_enceAlumno").val(resp["idApoderados"]);

            })
        }

    });
});



$(".RetirarAlumno").on("click", function () {

    var ids_array = [];
    $("input:checkbox[class=input_estudiantes]:checked").each(function () {

        ids_array.push($(this).val());

        if (ids_array.length > 0) {

            swal({
                title: '¿Está seguro de Retirar al Alumno?',
                text: "¡Si no lo está puede cancelar la acción!",
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                cancelButtonText: 'Cancelar',
                confirmButtonText: 'Si!'
            }).then(function (result) {

                   $.ajax({
                    url: "../Retirados/RegistrarRetirados",
                    data: {
                        codigo: $("#codigoAlumno").val(),
                        nombres: $("#nombreAlumno").val(),
                        apellidos: $("#apellidoeAlumno").val(),
                        correo: $("#correolumno").val(),
                        id_usuario: $("#id_Usuario").val(),
                        id_grado: $("#id_gradoAlumno").val(),
                        id_Seccion: $("#id_seccionAlumno").val(),
                        id_Encargado: $("#id_enceAlumno").val(),
                        motivo: $("#motivo").val(),
                        descripcion: $("#Descripción").val(),
                        dateTimeRetiro: $("#DateCreated").val()
                    },
                    type: 'POST'

                }).done(function (resp) {

                    window.location = "DeleteAlumnos?idAlumno=" + ids_array;

                })
               
              
            })
        }

    });
})


$(".retirar").prop('disabled', true);
var table = $("#tablass").DataTable();

$('.input_estudiantes').change(function () {
    var i = 0;
    table.$('input').each(function () {
        if ($(this).prop('checked') == true) {
            i++;
        } else {

        }
    });

    if (i == 0) {
        $(".retirar").prop('disabled', true);
    } else {
        $(".retirar").prop('disabled', false);
    }
});


$(".filter_Alumno").click(function () {

    $("#spiner-span").html("<span class='spinner-border spinner-border-sm' role=status' aria-hidden='true'></span>").delay(4000).hide("slow");
           
    $.ajax({

        url: "GetFilterAlumno",
        data: {
            id_grado: $("#Id_Grado_Filtrar").val(),
            id_seccion: $("#Section_Filter").val(),
            name: $("#NameEstudiante").val(),
            correo: $("#CorreoEstudiante").val(),
            codigo: $("#CodigoEstudiante").val()
        },
        type:'POST'

    }).done(function(Resp){

      // $("#spinner").html(" <div class='d-flex justify-content-center'><div class='spinner-border text-primary' style='align-content:center' role='status'><span class='sr-only'>Loading...</span></div><div class='spinner-grow text-primary ' role='status'><span class='sr-only'>Loading...</span></div><div class='spinner-grow text-primary ' role='status'><span class='sr-only'>Loading...</span></div></div><br>").delay(4000).hide("slow");
        if (Resp.nombres != null) {

       
            $('#tablass').html(`
                             <thead>
                                <tr>
                                    <th>Acciones</th>
                                    <th>Codigo</th>
                                    <th>Nombres</th>
                                    <th>Apellidos</th>
                                    <th>Correo</th>
                                    <th>Grado</th>
                                    <th>Seccion</th>
                                </tr>
                             </thead>

                                <tbody>

               
                                    <tr>
                                        <td style="text-align:center;" tabindex="0" class="sorting_1">

                                            <input type="checkbox" class="input_estudiantes" name="estudiantes[]" value="${Resp.idAlumno}">

                                            <button type="button" class="btn btn-primary" style="padding: 1px 5px; font-size: 12px; line-height: 1.5; border-radius: 3px; ">
                                                <span class="fa fa-user"></span>|<span class="fa fa-fw fa-money"></span>
                                            </button>

                                        </td>
                                        <td>${Resp.codigo}</td>
                                        <td>${Resp.nombres}</td>
                                        <td>${Resp.apellidos}"</td>
                                        <td>${Resp.correo}</td>
                                        <td>${Resp.idDegrees}</td>
                                        <td>${Resp.idSections}</td>
                                    </tr>


                            </tbody>
                                
                             `);
             

        } else {

            $('#tablass').html("<h4 class='text-center'>ALUMNO NO REGISTRADO</h4><div class='d-flex justify-content-center'><div class='spinner-border text-primary' style='align-content:center' role='status'><span class='sr-only'>Loading...</span></div></div><br>");

            
        }

       


    })
});