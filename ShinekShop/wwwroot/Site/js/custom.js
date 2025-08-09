var swal = require("sweetalert2");

// Add PageId To Filter Form
function ChangePageId(pageId) {
    const form = document.getElementById("filter-data-form");
    const input = document.getElementById("PageId");
    input.value = pageId;
    form.submit();
}

// Filter Product Order
document.addEventListener("DOMContentLoaded", function () {
    const currentOrder = document.getElementById("orderInput").value;
    const links = document.querySelectorAll("a[data-order-index]");

    links.forEach(link => {
        if (link.getAttribute("data-order-index") === currentOrder) {
            link.classList.add("active_custom");
        }

        link.addEventListener("click", function (e) {
            e.preventDefault();
            const orderValue = this.getAttribute("data-order-index");
            document.getElementById("orderInput").value = orderValue;

            setTimeout(() => {
                document.getElementById("filter-product-form").submit();
            }, 10);
        });
    });
});

// Submit Filter Order From Select Tag
function submitOrder(valueIndex) {
    const input = document.getElementById("orderInput");
    input.value = valueIndex;

    setTimeout(() => {
        document.getElementById("filter-product-form").submit();
    }, 10);
}

