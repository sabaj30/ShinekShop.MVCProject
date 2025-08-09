// Change Base Price
function updateProductPrice() {
    const basePriceInput = document.getElementById("base-price");
    const basePriceValue = parseInt(basePriceInput.getAttribute("product-price"));
    const selectedVariant = document.querySelector('input[name="variantId"]:checked');
    const variantPrice = parseInt(selectedVariant.getAttribute("variant-price"));
    const finalPrice = basePriceValue + variantPrice;
    document.getElementById("base-price").innerHTML = finalPrice.toLocaleString();

    //Add Variant id To Form
    const variantInput = document.getElementById("ProductVariantId");
    const selectedVariantId = selectedVariant?.value;
    variantInput.value = selectedVariantId;
}

document.querySelectorAll('input[name="variantId"]').forEach(radio => {
    radio.addEventListener("change", updateProductPrice);
});

document.addEventListener("DOMContentLoaded", updateProductPrice);

//Add Product To Cart AJAX
function addProductToCart() {
    const selectedVariant = document.querySelectorAll('input[name="variantId":checked]');
    const quantity = document.getElementById("productQuantity").value;
    const selectedVariantId = selectedVariant?.value;

    fetch("add-product-to-cart",
        {
            method: "POST",
            headers: {
                'Content-Type': "application/json"
            },
            body: JSON.stringify({ selectedVariantId, quantity })
        }).then(res => {
            if (!res.ok) throw new ERROR("ارسال ناموفق بود");
            return res.JSON();
        }).then(data => {
            function showError() {
                swal.fire({
                    title: "پیغام خطا",
                    text: "عملیات ناموفق بود",
                    icon: "error",
                    width: "28em",
                    confirmButtonText: "باشه"
                });
            };
        });
};

//document.getElementById("addToCartBtn").addEventListener("click", addProductToCart());

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
    const productId = $("#favorite-btn").data("product-id");

    $("#favorite-icon").click(function () {
        open_waiting();
        $.post("/toggle-favorite-product", { productId: productId })
            .done(function (data) {
                if (data.isFavorite) {
                    $("#favorite-icon").removeClass("bi-heart").addClass("bi-heart-fill favorite");
                } else {
                    $("#favorite-icon").removeClass("bi-heart-fill favorite").addClass("bi-heart");
                }
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
                        text: "برای افزودن محصول به لیست علاقمندی ها باید وارد حساب کاربری خود شوید.",
                        icon: "error",
                        width: "28em",
                        confirmButtonText: "باشه"
                    });
                };
            });
    });

    $.get("/is-favorite", { productId: productId }, function (data) {
        if (data.isFavorite) {
            $("#favorite-icon").removeClass("bi-heart").addClass("bi-heart-fill favorite");
        } else {
            $("#favorite-icon").removeClass("bi-heart-fill favorite").addClass("bi-heart");
        }
    });
});

$(document).ready(function () {
    $(".commentTags").tagify();
});