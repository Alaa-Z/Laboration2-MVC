// make option fot select from 1 to 8 
var selectYear = document.getElementById("selectYear");
var val;

for (let i = 1; i <= 8; i++) {
  val += "<option>" + i + "</option>";
}

selectYear.innerHTML = val;