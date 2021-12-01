function listar_Seccion() {
    $.ajax({
        url: "ListarSeccion",
        type: 'GET'
    }).done(function (resp) {
    
        var seccion = '<option selected disabled>Selecionar Seccion</option>';
        for (var i = 0; i < resp.length; i++) {

            seccion += `<option value="${resp[i].idSection}">${resp[i].sectionName}</option> `
        }

        $('#DatosSeccion').html(seccion);
        $('#Section_Filter').html(seccion);
    })

}

function listar_Grado() {
    $.ajax({
        url: "ListarGrado",
        type: 'GET'
    }).done(function (resp) {

        var Grado = '<option selected disabled>Selecionar Grado</option>';
        for (var i = 0; i < resp.length; i++) {

            Grado += `<option value="${resp[i].idDegree}">${resp[i].degreeName}</option> `
        }

        $('#GradoAlumno').html(Grado);
        $('#Id_Grado_Filtrar').html(Grado);
    })

}

$("#ConfirmarAlumno").blur(function () {
    if ($("#display").val() === $("#ConfirmarAlumno").val()) {
        $("#Success").html("<h8> Looks good!</h8>");
        $("#ConfirmarAlumno").css({ "border-color": "green" });
        $("#display").css({ "border-color": "green" });
        $("#Error").html("");
        $(".btn-register").prop('disabled', false);
    } else {

        $("#Error").html("<h8>Las contraseñas no son iguales</h8>");
        $("#ConfirmarAlumno").css({ "border-color": "red" });
        $("#display").css({ "border-color": "red" });
        $("#Success").html("");
        $(".btn-register").prop('disabled', true);
    }
});



$("#inputNombreAlumno").blur(function () {
    if ($("#inputNombreAlumno").val() != '') {
        $.ajax({
            url: "ExistenciaName",
            type: 'Post',
            data: { nombres: $("#inputNombreAlumno").val() }
        }).done(function (result) {
            if (result == true) {

                $("#NombreExiste").html("<h8>Estudiante ya existe <h8>");
                $("#NombreExistes").html("");
                $("#inputNombreAlumno").css({ "border-color": "red" });
                $("#Chekname").show("slow").delay(2000).hide("slow");
                $(".btn-register").prop('disabled', true);
            } else {
                $("#NombreExistes").html("<h8> Looks good! <h8>");
                $("#NombreExiste").html("");
                $("#inputNombreAlumno").css({ "border-color": "green" });
                $(".btn-register").prop('disabled', false);
            }
        })
    }
});


$(".btn-register").click(function () {

    if ($("#inputNombreAlumno").val() != "" && $("#inputNombre").val() != "" && $("#inputApellidoP").val() != "" && $("#inputApellidoM").val() != "" &&
        $("#ConsultDNI").val() != "" && $("#inputTelefono").val() != "" && $("#parentesco").val() != "" && $("#inputCodigo").val() != "" && $("#display").val() != ""
        && $("#IdRol").val() != "" && $("#inputCodigo").val() != "" && $("#inputApellido").val() != "" && $("#InputCorreoAlumno").val() != "" && $("#GradoAlumno").val() != "" && $("#DatosSeccion").val() != "") {

        var as = $("#inputNombreAlumno").val();
        $.ajax({
            url: "ExistenciaName",
            data: {
                nombres: $("#inputNombreAlumno").val()
            },
            type: 'POST'
        }).done(function (RESP) {

            if (RESP != true) {

                $.ajax({
                    url: "RegistrarApoderado",
                    data: {
                        nombre: $("#inputNombre").val(),
                        apellidoP: $("#inputApellidoP").val(),
                        apellidoM: $("#inputApellidoM").val(),
                        dni: $("#ConsultDNI").val(),
                        telefono: $("#inputTelefono").val(),
                        parentesco: $("#parentesco").val()

                    },
                    type: 'POST'

                }).done(function (resp) {

                    $.ajax({
                        url: "RegistrarUsuario",
                        data: {
                            userName: $("#inputNombreAlumno").val(),
                            codigo: $("#inputCodigo").val(),
                            pass: $("#display").val(),
                            roleIdRole: $("#IdRol").val()
                        },
                        type: 'POST'

                    }).done(function (resp) {
                        $.ajax({
                            url: "ObtenerUsario",
                            type: 'GET'
                        }).done(function (resp) {
                            for (var i = 0; i < resp.length; i++) {
                                var idUsers = resp[i].idUser;
                            }
                            var idUser = idUsers;
                            $('#idUsers').val(idUser);
                            $.ajax({
                                url: "ObtenerApoderado",
                                type: 'GET'
                            }).done(function (resp) {
                                for (var i = 0; i < resp.length; i++) {
                                    var idPod = resp[i].idApoderado;
                                }
                                var idPoderado = idPod;
                                $('#ApoderadoId').val(idPoderado);

                                $.ajax({
                                    url: "Registrar",
                                    data: {
                                        codigo: $("#inputCodigo").val(),
                                        nombres: $("#inputNombreAlumno").val(),
                                        apellidos: $("#inputApellido").val(),
                                        correo: $("#InputCorreoAlumno").val(),
                                        idUsers: $("#idUsers").val(),
                                        idDegrees: $("#GradoAlumno").val(),
                                        idSections: $("#DatosSeccion").val(),
                                        idApoderados: $("#ApoderadoId").val()

                                    },
                                    type: 'POST'

                                }).done(function (resp) {
                                    swal({
                                        type: "success",
                                        title: "El alumno registro correctamente",
                                        showConfirmButton: true,
                                        confirmButtonText: "Cerrar",
                                        closeOnConfirm: false
                                    }).then(function (result) {
                                        if (result.value) {
                                            window.location = "Registrar";
                                        }
                                    })
                                })

                            })

                        })

                    })

                })

            } else {

                $("#Chekname").show("slow").delay(2000).hide("slow");
                return;
            }
        })
    } else {

        $("#Cheknames").show("slow").delay(2000).hide("slow");
        return;
    }
});




