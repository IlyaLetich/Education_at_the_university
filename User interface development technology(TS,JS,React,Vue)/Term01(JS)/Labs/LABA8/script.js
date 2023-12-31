$(document).ready(function () {
   $(".dws-form").on("click", ".tab", function () {
      // Удаляем классы active
      $(".dws-form").find(".active").removeClass("active");

      //Добавляем класс active
      $(this).addClass("active");
      $(".tab-form").eq($(this).index()).addClass("active");


      const form = document.getElementById("form");
      const username = document.getElementById("username");
      const email = document.getElementById("email");
      const password = document.getElementById("password");
      const password2 = document.getElementById("password2");

      checkEmail(email.input);

      // Показываем ошибку под полем
      function showError(input, message) {
         const formControl = input.parentElement;
         formControl.className = "form-control error";
         const small = formControl.querySelector("small");
         small.innerText = message;
      }

      // Показываем, что поле заполнено верно
      function showSuccess(input) {
         const formControl = input.parentElement;
         formControl.className = "form-control success";
      }

      // Проверяем адрес электронной почты на правильность
      function checkEmail(input) {
         const re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
         if (re.test(input.value.trim())) {
            showSuccess(input);
         } else {
            showError(input, "Адрес электронной почты имеет неверный формат");
         }
      }
   });
});