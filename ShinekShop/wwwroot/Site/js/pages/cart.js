// Open Wait me Animation
function open_waiting(selector = "body") {
    $(selector).waitMe({
        effect: "facebook",
        text: "لطفا صبر کنید ...",
        bg: "rgba(255,255,255,0.7)",
        color: "#000"
    });
}

// Close WaitMe 
function close_waiting(selector = "body") {
    $(selector).waitMe("hide");
}

// Increase Or Decrease Order Detail Count
$(document).ready(function () {
    $('#cart-page-content').on("change", ".count-input", function () {
        open_waiting();
        const orderDetailId = $(this).data("id");
        const newCount = $(this).val();
        const token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: "/change-order-detail-count",
            type: "POST",
            data: {
                orderDetailId: orderDetailId,
                newCount: newCount
            },
            headers: {
                "RequestVerificationToken": token
            },
            success: function (updatedCartContent) {
                $("#cart-page-content").html(updatedCartContent);
                touchSpinLoading();
                setTimeout(function () {
                    close_waiting();
                }, 1000);
            },
            error: function () {
                $(document).ready(function () {
                    swal.fire({
                        title: "پیغام خطا",
                        text: 'تغییر تعداد سفارش با خطا مواجه شد',
                        icon: "error",
                        width: '28em',
                        confirmButtonText: "باشه"
                    });
                });
                setTimeout(function () {
                    close_waiting();
                }, 1000);
            }
        });
    });
});

// Remove Order Detail
$(document).ready(function () {
    $('#cart-page-content').on("click", ".remove-order-detail", function () {
        open_waiting();
        const orderDetailId = $(this).data("id");
        const token = $('input[name="__RequestVerificationToken"]').val();

        $.ajax({
            url: "/delete-order-item",
            type: "POST",
            data: {
                orderDetailId: orderDetailId
            },
            headers: {
                "RequestVerificationToken": token
            },
            success: function (updatedCartContent) {
                $("#cart-page-content").html(updatedCartContent);
                touchSpinLoading();
                setTimeout(function () {
                    close_waiting();
                }, 1000);
            },
            error: function () {
                $(document).ready(function () {
                    swal.fire({
                        title: "پیغام خطا",
                        text: 'حذف آیتم سفارش با خطا مواجه شد',
                        icon: "error",
                        width: '28em',
                        confirmButtonText: "باشه"
                    });
                });
                setTimeout(function () {
                    close_waiting();
                }, 1000);
            }
        });
    });
});

function touchSpinLoading() {
    $("input[name='count']").TouchSpin({
        min: 1,
        max: '5',
        buttondown_class: "btn-counter waves-effect waves-light",
        buttonup_class: "btn-counter waves-effect waves-light"
    });
}

$(document).ready(touchSpinLoading);               