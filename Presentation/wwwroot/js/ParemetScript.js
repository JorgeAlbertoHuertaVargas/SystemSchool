function listar_Paraments() {
    $.ajax({
        "url": "Paremet/GetParamets",
        type: 'GET'
    }).done(function (resp) {
        console.log(resp);
        if (resp.length != 0) {
            var cont = 1;
            var template = '';
            resp.forEach(valor => {
                template += `
                                <tr guardarId="${valor.paremetId}" >
                                <td>${cont}</td>
                                 <td>${valor.paremetName}</td>
                                 <td>${valor.status}</td>
                                 <td>${valor.roles.roleName}</td>
                                  <td>
                                   <button class='btn btn-info' onclick = 'AddParamets(this)' style=' font-size:13px;'><i class=' fa-eye-slash' style='color:White '></button></i>&nbsp;
                               </td>

                                  </tr>
                                          `
                cont++;
            })
            $('#contenido').html(template);

        } else {
            $('#contenido').html('NO HAY REGISTRO');
        }
    }).fail(function (xhr, status, error) {

    });

}

function AddParamets(t) {
    var td = t.parentNode;
    var tr = td.parentNode;
    var idpatamet = $(tr).attr('guardarId');
    $("#modal_ADD").modal({
        backdrop: 'static',
        keyboard: false
    })
    $(".modal-header").css("background-color", "#ea899a");
    $(".modal-header").css("color", "white");
    $("#modal_ADD").modal('show');
    $("#Parametid").val(idpatamet);
}

function Registrar() {
    var ParemetId = $("#Parametid").val();
    var Statusnew = $("#StatusNuevo").val();
    var RoleId = $("#RoleId").val();
    alert(Statusnew);

    if (ParemetId.length == 0 || RoleId.length == 0 || Statusnew.length == 0) {

        $("#llenecamp").show();
        return;
    }
    $.ajax({
        url: "Paremet/Registrar",
        type: 'POST',
        data: {
            ParemetId: ParemetId,
            Statusnew: Statusnew,
            RoleId: RoleId
        },
    }).done(function (resp) {
        console.log(resp);
        if (resp.length != 0) {
            $("#modal_ADD").modal('hide');
            listar_Paraments();
        } else {
            console.log("Mensaje De Advertencia", "No se pudo register!!", "warning");
        }
    })

}