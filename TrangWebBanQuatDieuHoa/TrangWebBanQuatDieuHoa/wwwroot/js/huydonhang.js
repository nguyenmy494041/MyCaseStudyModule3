var order = order || {};
order.delete = function (id) {
    bootbox.confirm({
        title: "Cảnh báo",
        message: "Bạn muốn hủy đơn hàng này không?",
        buttons: {
            cancel: {
                label: '<i class="fa fa-times"></i> Không'
            },
            confirm: {
                label: '<i class="fa fa-check"></i> Có'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: `/Product/Delete/${id}`,
                    method: "GET",
                    contentType: 'json',
                    success: function (data) {
                        if (data) {
                            window.location = "/Product/Showorder";
                        }
                    }
                });
            }
        }
    });
}