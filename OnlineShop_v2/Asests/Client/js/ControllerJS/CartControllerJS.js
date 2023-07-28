var cart = {
    init: function () {
        cart.resRvent();
    },
    resRvent: function () {
        $('#continueBtn').off('click').on('click', function () {
            window.location.href = "/"
        })

        // Thanh toán
        $('#PaymentBtn').off('click').on('click', function () {
            window.location = "/thanh-toan"
        })

        // Cập nhật cửa hàng
        $('#UpdateBtn').off('click').on('click', () => {
            var listProduct = $('.txtQuantity')
            var cartList = []
            $.each(listProduct, function (i, item) {
                cartList.push({
                    Quanlity: $(item).val(),
                    product: {
                        ID: $(item).data('id')
                    }
                })
            })

            $.ajax({
                url: "/Cart/Update",
                data: { cartModel: JSON.stringify(cartList) },
                dataType: "json",
                type: 'POST',
                success: (res) => {
                    if (res == true) {
                        Swal.fire({
                            icon: 'success',
                            title: 'Cập nhật giỏ hàng thành công',
                            showConfirmButton: false,
                            timer: 2500
                        })

                        window.location.href = '/gio-hang'
                    }
                }
            })
        })

        // Xóa toàn bộ cửa hàng
        $('#DeleteBtn').off('click').on('click', function () {
            $.ajax({
                url: "/Cart/DeleteAll",
                dataType: "json",
                type: 'POST',
                success: (res) => {
                    if (res.status == true) {
                        Swal.fire({
                            title: 'Bạn có chắc?',
                            text: "Bạn muốn xóa toàn bộ giỏ hàng?",
                            icon: 'warning',
                            showCancelButton: true,
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            confirmButtonText: 'Xóa!'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                Swal.fire(
                                    'Xóa tất cả!',
                                    'Toàn bộ giỏ hàng sẽ bị xóa',
                                    'success'
                                )

                                window.location = '/gio-hang'
                            }
                        })

                    }
                }
            })
        })

        //Xóa một sản phẩm trong cửa hàng
        $('.deleteProdBtn').off('click').on('click', function () {
            $.ajax({
                url: "/Cart/DeleteItem",
                data: { id: $(this).data('id') },
                dataType: "json",
                type: 'POST',
                success: (res) => {
                    if (res.status == true) {
                        Swal.fire({
                            title: 'Bạn có chắc?',
                            text: "Bạn muốn xóa toàn bộ giỏ hàng?",
                            icon: 'warning',
                            showCancelButton: true,
                            confirmButtonColor: '#3085d6',
                            cancelButtonColor: '#d33',
                            confirmButtonText: 'Xóa!'
                        }).then((result) => {
                            if (result.isConfirmed) {
                                Swal.fire(
                                    {
                                        title: 'Xóa tất cả!',
                                        text: 'Toàn bộ giỏ hàng sẽ bị xóa',
                                        icon: 'success',
                                        showConfirmButton: false,
                                        timer: 2500
                                    }
                                )

                                window.location = '/gio-hang'
                            }
                        })

                    }
                }
            })
        })


        // Hàm ajax xử lý sự kiện thêm vào giỏ hàng
        //$('.addToCartBtn').off('click').on('click', function () {
        //    var result = []

        //    result.push({
        //        productID: $(this).data('id'),
        //        Quantity: 1
        //    })

        //    var productID = $(this).data('id')
        //    var Quantity = 1 

        //    console.log(result)

        //    $.ajax({
        //        url: '/Cart/AddToCartAjax',
        //        type: 'POST',
        //        data: { productID: productID, Quantity: Quantity },
        //        dataType: 'json',
        //        success: function (res) {
        //            if (res.status == true) {
        //                console.log("Thành công")

        //                Swal.fire({
        //                    icon: 'success',
        //                    title: 'Thêm sản phẩm vào giỏ hàng thành công',
        //                    showConfirmButton: false,
        //                    timer: 2500
        //                })

        //                // Reload cart items in the header
        //                //$.ajax({
        //                //    url: "/BaseClient/_HeaderTop",
        //                //    type: 'GET',
        //                //    dataType: 'html',
        //                //    success: function (res) {
        //                //        $('.cart-content-item').html(res);
        //                //    }
        //                //});

        //            }
        //        },
        //        error: function () {
        //            Swal.fire({
        //                icon: 'error',
        //                title: 'Oops...',
        //                text: 'Thêm giỏ hàng thất bại.',
        //            })
        //        }

        //    })
        //})
    }
}

cart.init();