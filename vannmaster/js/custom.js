// slider

let dot_count = 3;
let current_dot_num = 1;
let last_dot_update_date = Date.now();
let imgPath = "img/header";
let imgSource = ".jpg";

function changeImg(dot_num) {
 $('#slider').fadeOut(500, function(){
  document.getElementById("slider").src = imgPath + dot_num.toString() + imgSource;
  $('#slider').fadeIn(500);
 });
 $('.cus-dot').fadeOut(500, function(){
  for (i = 1; i <= dot_count; i++){
   if (i == dot_num){
    document.getElementById("slider-dot-"+i.toString()).classList.remove("dot-not-active");
    document.getElementById("slider-dot-"+i.toString()).classList.add("dot-active");
    current_dot_num = dot_num;
   } else{
    document.getElementById("slider-dot-"+i.toString()).classList.remove("dot-active");
    document.getElementById("slider-dot-"+i.toString()).classList.add("dot-not-active");
   }
  }
  $('.cus-dot').fadeIn(500);
 });
 last_dot_update_date = Date.now();
}

function runSlider(){
 var newDate = Date.now();
 newDate = (newDate - last_dot_update_date) / 1000;
 if (newDate > 10){
  if (current_dot_num + 1 > dot_count){
   current_dot_num = 1;
  } else{
   current_dot_num = current_dot_num + 1;
  }
  changeImg(current_dot_num);
  }
}

let sliderTimer = setInterval(() => runSlider(), 1000);

// menu scrolls

let services = document.getElementById("main");
let order = document.getElementById("order");
let footer = document.getElementById("footer");

function scrollAction(num){
 if (num == 1){
  services.scrollIntoView({block: "center", behavior: "smooth"});
 }else if (num == 2){
  order.scrollIntoView({block: "center", behavior: "smooth"});
 }else if (num == 3){
  footer.scrollIntoView({block: "center", behavior: "smooth"});
 }
}