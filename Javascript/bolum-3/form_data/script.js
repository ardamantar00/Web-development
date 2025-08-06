const form = document.getElementById("form");

function onSubmit(e) {
  e.preventDefault();

  const inputValue = document.getElementById("input").value;
  const selectedValue = document.getElementById("select").value;
  const checkedValue = document.getElementById("checkbox").checked;

  if (inputValue == "" || selectedValue == "0") {
    alert("Formu doldurunuz");
    return;
  }
  console.log(inputValue, selectedValue, checkedValue);

  console.log("Form Submit");
}

function onSubmit2(e) {
  e.preventDefault();

  const formData = new FormData(form);
  const selectValue = formData.get("select");
  const inputValue = formData.get("input");

  let checkedValue = false;

  if (formData.get("checkbox") == "on") {
    checkedValue = true;
  }

  if (inputValue == "" || selectValue == "0") {
    alert("Formu doldurunuz");
    return;
  }
  const entries = formData.entries();
  for (let entry of entries) {
    console.log(entry);
  }

  console.log(inputValue, selectValue, checkedValue);

  console.log("Form Submit");
}
// form.addEventListener("submit", onSubmit);
form.addEventListener("submit", onSubmit2);
