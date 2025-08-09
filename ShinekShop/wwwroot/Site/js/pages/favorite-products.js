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

// Add Product To Favorite
$(document).ready(function () {
    $("#remove").click(function () {
        const productId = $(this).data("product-id");
        open_waiting();
        $.post("/toggle-favorite-product", { productId: productId })
            .done(function (data) {
                $(`#item-container-${productId}`).remove();
                setTimeout(function () {
                    close_waiting();
                }, 1000);
            })
            .fail(function () {
                setTimeout(function () {
                    close_waiting();
                }, 1000);
                function showError() {
                    swal.fire({
                        title: "پیغام خطا",
                        text: "حذف محصول از لیست علاقمندی ها با خطا مواجه شد.",
                        icon: "error",
                        width: "28em",
                        confirmButtonText: "باشه"
                    });
                };
            });
    });
});