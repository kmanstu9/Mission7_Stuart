<script>
    document.addEventListener("DOMContentLoaded", function () {
        const form = document.querySelector("form");
    const notesInput = document.querySelector("[name='Notes']");
    const submitButton = document.querySelector("button[type='submit']");

        // Make everything except "Lent To" and "Notes" required
        document.querySelectorAll("input, select").forEach(input => {
            if (input.name !== "Lent" && input.name !== "Notes") {
        input.setAttribute("required", "required");
            }
        });

    // Limit "Notes" field to 25 characters
    notesInput.addEventListener("input", function () {
            if (this.value.length > 25) {
        this.value = this.value.substring(0, 25);
            }
        });

    // Add a button to clear the form
    const clearButton = document.createElement("button");
    clearButton.type = "button";
    clearButton.textContent = "Clear";
    clearButton.style.marginLeft = "10px";
    submitButton.insertAdjacentElement("afterend", clearButton);

    clearButton.addEventListener("click", function () {
        form.reset();
        });
    });
</script>
