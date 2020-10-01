var dangky = dangky || {};

dangky.thaydoitinhthanh = function (id) {
    dangky.vedanhsachquanhuyen(id);
}

dangky.vedanhsachquanhuyen = function (TinhThanhId) {
    $.ajax({
        url: `/Order/TinhThanh/${TinhThanhId}`,
        method: "GET",
        contentType: "json",
        success: function (data) {

            $("#QuanHuyenId").empty();
            $.each(data.quanhuyens, function (i, v) {

                $("#QuanHuyenId").append(`
                     <option value=${v.quanHuyenId}>${v.tenDayDu}</option>
                `);
            });

            dangky.vedanhsachphuongxa($("#QuanHuyenId").val());
        }
    });
}


dangky.thaydoiquanhuyen = function (id) {
    dangky.vedanhsachphuongxa(id);
}

dangky.vedanhsachphuongxa = function (QuanHuyenId) {
    $.ajax({
        url: `/Order/TinhThanh/QuanHuyen/${QuanHuyenId}`,
        method: "GET",
        contentType: "json",
        success: function (data) {

            $("#PhuongXaId").empty();
            $.each(data.phuongxas, function (i, v) {

                $("#PhuongXaId").append(`
                     <option value=${v.phuongXaId}>${v.tenDayDu}</option>
                `);
            });

        }

    });

}