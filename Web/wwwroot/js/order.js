

var dtable;
$(document).ready(function () {
    loaddata();
});

function loaddata() {
    dtable = $('#mytable').DataTable({
        "ajax": {
            "url": "/Admin/Order/GetData"
        },
        "columns": [

            { "data": "id" },
            { "data": "name" },
            { "data": "phoneNumber" },
            { "data": "applicationUser.email" },
            { "data": "orderStatus" },
            { "data": "totalPrice" },
            {
                "data": "id",
                "render": function (data) {
                    return   `
                             
                    <a href="/Admin/Order/Details/${data}" class="btn btn-warning">Details</a>
                             `
                }
            }
        ]
    });
}

