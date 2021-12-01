
function active() {
    turn = document.getElementById("comboTurno").value;
    val = 0;
    /*alert(id);*/
    if (turn == "") {
        val++;
    }
    if (val == 0) {
        document.getElementById("comboNivel").disabled = false;
        $.ajax({
            url: "GetLevelByTurn",
            type: 'GET',
            data: {
                turn: $("#comboTurno").val(),
            },
        }).done(function (resp) {
            /*alert('Hola');*/
                var Turn = '<option value="">Seleccione</option>';
                for (var i = 0; i < resp.length; i++) {
                    Turn += `<option value="${resp[i].id}">${resp[i].levelname}</option> `
                }
            $('#comboNivel').html(Turn);

            document.getElementById("comboNivel").addEventListener("change", activegrado);
        })
        
    }
}

document.getElementById("comboTurno").addEventListener("change", active);


function activegrado() {
    document.getElementById("comboGrado").disabled = false;
    var prueba = $('#comboNivel').val();
    /*alert(prueba);*/
    $.ajax({
        url: "GetDegreeByIdLevel",
        type: 'GET',
        data: {
            id: prueba
        }
    }).done(function (resp) {
        /*alert(resp);*/
        var Degree = '<option value="">Seleccione</option>';
        for (var i = 0; i < resp.length; i++) {
            Degree += `<option value="${resp[i].idDegree}">${resp[i].degreeName}</option> `
        }
        $('#comboGrado').html(Degree);
        document.getElementById("comboGrado").addEventListener("change", activecurso);
    })
}

function activecurso() {
    document.getElementById("comboCurso").disabled = false;
    var prueba = $('#comboGrado').val();
    /*alert(prueba);*/
    $.ajax({
        url: "GetGradosCurso",
        type: 'GET',
        data: {
            idDegree: prueba
        }
    }).done(function (resp) {
        var Course = '<option value="">Seleccione</option>';
        for (var i = 0; i < resp.length; i++) {
            Course += `<option value="${resp[i].coursesIdCourse}">${resp[i].courses.courseName}</option> `
        }
        $('#comboCurso').html(Course);
        
        document.getElementById("comboCurso").addEventListener("change", activeseccion);
    })

    
}

function activeseccion() {
    document.getElementById("comboSeccion").disabled = false;
    $.ajax({
        url: "GetAllSection",
        type: 'GET'
    }).done(function (resp) {
        var Section = '<option value="">Seleccione</option>';
        for (var i = 0; i < resp.length; i++) {
            Section += `<option value="${resp[i].idSection}">${resp[i].sectionName}</option> `
        }
        $('#comboSeccion').html(Section);
        document.getElementById("comboSeccion").addEventListener("change", AssignCourseDegree);
    })
}

function AssignCourseDegree() {
    /*alert('Hola');*/
    turn = document.getElementById("comboTurno").value;
    lvl = document.getElementById("comboNivel").value;
    degree = document.getElementById("comboGrado").value;
    course = document.getElementById("comboCurso").value;
    sec = document.getElementById("comboSeccion").value;
    var valor = 0;

    if (turn == "" ) {
        valor++;
    }
    if (lvl == "" ) {
        valor++;
    }
    if (degree == "" ) {
        valor++;
    }
    if (course == "" ) {
        valor++;
    }
    if (sec == "") {
        valor++;
    }
    if (valor==0) {
        document.getElementById("btn-register-assign").disabled = false;
    }

}

$("#btn-register-assign").click(function () {
    var turno = document.getElementById('comboTurno').value;
    var nivel = document.getElementById('comboNivel').value;
    var grado = document.getElementById('comboGrado').value;
    var curso = document.getElementById('comboCurso').value;
    var seccion = document.getElementById('comboSeccion').value;

    if (turno.length != 0 && nivel.length != 0 && grado.length != 0 && curso.length != 0 && seccion.length != 0) {
        console.log('Mal');
        $.ajax({
            url: "AddAssignTeacher",
            type: 'POST',
            data: {
                TeacherIdTeacher: $("#comboTeacher").val(),
                turnName: $("#comboTurno").val(),
                levelId : $("#comboNivel").val(),
                degreeIdDegree: $("#comboGrado").val(),
                courseIdCourse: $("#comboCurso").val(),
                sectionIdSection: $("#comboSeccion").val()
            }
        }).done(function (resp) {
            if (resp != null) {
                var id = resp.teacherIdTeacher;
                swal({
                    type: "success",
                    title: "La sección se registró correctamente",
                    showConfirmButton: true,
                    confirmButtonText: "Cerrar",
                    closeOnConfirm: false
                }).then(function (result) {
                        if (result.value) {
                            window.location = "Assign?idTeacher=" + id;
                        }
                })
            }
        })
    } else {
        $("#validationform").show("slow").delay(2000).hide("slow");
        return;
    }
})

//***************************************************************

function List_Assign() {
    
    var idteacher = $("#comboTeacher").val();
    /*alert('Hola');*/
    $.ajax({
        url: "GetAllAssignTeacher",
        type: 'GET',
        data: {
            id: idteacher
        }

    }).done(function (resp) {
        /*alert('Hola');*/
        /*console.log(resp);*/
        var cont = 1;
        if (resp.length != 0) {
            var cont = 1;
            var template = '';
            for (var i = 0; i < resp.length; i++) {

                template += `
                             <tr guardarId="${resp[i].idAssignTLDCS}">
                             <td><a>${resp[i].turnName}</a></td>
                             <td><a>${resp[i].level.levelname}</a></td>
                             <td><a>${resp[i].degree.degreeName}</a></td>
                            <td><a>${resp[i].section.sectionName}</a></td>
                            <td><a>${resp[i].course.courseName}</a></td>
                            <input id="idteacher" type="hidden" value="${resp[i].teacherIdTeacher}">
                             <td>
                              <button type="reset" class="btn btn-danger"  onclick='DeleteAssign(this)'><i class="fas fa-times"></i></button>
                             </td>
                                
                             `
                cont++;
            }
            $('#Lista').html(template);

        }

    })

}

function DeleteAssign(t) {
    
    swal({
        title: '¿Está seguro de quitar la asignación al docente?',
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
            var idAssign = $(tr).attr('guardarId');
            var idtea = $("#idteacher").val();
            console.log(idtea);
            $.ajax({
                url: "DeleteAssign",
                type: 'POST',
                data: {
                    id: idAssign
                },
            }).done(function (resp) {
                
                console.log(idtea);
                window.location = "Assign?idTeacher=" + idtea;
            })
        }
    })
}



