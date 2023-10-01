<template>
   <div id="carouselExampleCaptions" class="carousel slide">
      <div class="carousel-indicators home__carousel-indicators">
         <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active"
            aria-current="true" aria-label="Slide 1"></button>
         <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1"
            aria-label="Slide 2"></button>
         <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2"
            aria-label="Slide 3"></button>
         <button type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide-to="3"
            aria-label="Slide 4"></button>
      </div>
      <div class="carousel-inner">
         <div class="carousel-item active">
            <img src="../assets/Rectangle.png" class="d-block w-100" alt="">
            <div class="carousel-caption home__carousel-caption   d-none d-md-block">
               <h5>Бухгалтерские услуги в Санкт-Петербурге</h5>
               <p><button class="btn btn-primary btn-lg home__btn.btn-primary.btn-lg">Наша презентация</button></p>
            </div>
         </div>
         <div class="carousel-item">
            <img src="../assets/Rectangle.png" class="d-block w-100" alt="">
            <div class="carousel-caption home__carousel-caption  d-none d-md-block">
               <h5>Бухгалтерские услуги в Санкт-Петербурге</h5>
               <p><button class="btn btn-primary btn-lg home__btn.btn-primary.btn-lg">Наша презентация</button></p>
            </div>
         </div>
         <div class="carousel-item">
            <img src="../assets/Rectangle.png" class="d-block w-100" alt="">
            <div class="carousel-caption home__carousel-caption   d-none d-md-block">
               <h5>Бухгалтерские услуги в Санкт-Петербурге</h5>
               <p><button class="btn btn-primary btn-lg home__btn.btn-primary.btn-lg">Наша презентация</button></p>
            </div>
         </div>
         <div class="carousel-item">
            <img src="../assets/Rectangle.png" class="d-block w-100" alt="">
            <div class="carousel-caption home__carousel-caption  d-none d-md-block">
               <h5>Бухгалтерские услуги в Санкт-Петербурге</h5>
               <p><button class="btn btn-primary btn-lg home__btn.btn-primary.btn-lg">Наша презентация</button></p>
            </div>
         </div>
      </div>
      <button class="carousel-control-prev home__carousel-control-prev" type="button"
         data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
         <span class="carousel-control-prev-icon home__carousel-control-next-icon" aria-hidden="true"></span>
         <span class="visually-hidden">Previous</span>
      </button>
      <button class="carousel-control-next home__carousel-control-next" type="button"
         data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
         <span class="carousel-control-next-icon home__carousel-control-next-icon" aria-hidden="true"></span>
         <span class="visually-hidden">Next</span>
      </button>
   </div>
</template>

<style lang="scss">
.home {
   &__carousel-indicators {
      position: absolute;
      margin: 0;
      margin-bottom: 110px;
      left: 215px;
      width: auto;
      z-index: 2;
      display: flex;
      justify-content: left;
      padding: 0;

      [data-bs-target] {
         border-radius: 50%;
         width: 0px;
         height: 0;
         margin-right: 30px;
         margin-left: 3px;
         padding: 10px 0px 0px 10px;

      }
   }

   &__carousel-control-next,
   &__carousel-control-prev {
      position: absolute;
      margin-top: 350px;
      bottom: 0;
      z-index: 1;
      width: 60px;
      height: 60px;
      justify-content: center;
      padding: 30px;
      color: #fff;
      text-align: center;
      background: rgba(255, 255, 255, 0.396);
      border: 0;
      opacity: .5;
      transition: opacity .15s ease;
      left: 1200px;
   }

   &__carousel-control-next {
      left: 1260px;
   }

   &__carousel-control-next-icon,
   &__carousel-control-prev-icon {
      display: block;
      height: 20px;
      width: 23px;
      padding: 10px;
      background-size: 100% 100%;
      justify-content: center;
      color: #000;
   }

   &__carousel-caption {
      position: absolute;
      right: 0;
      bottom: 34%;
      left: 215px;
      padding-top: 0;
      padding-bottom: 0;
      color: #fff;
      text-align: left;

      p {
         font-family: 'Lato';
         font-style: normal;
         font-weight: 400;
         font-size: 18px;
         line-height: 25px;

         .btn.btn-primary.btn-lg {
            border-radius: 0;
            width: 270px;
            height: 60px;
            left: 0px;
         }
      }

      h5 {
         width: 589px;
         height: 117px;
         margin-bottom: 100px;
         font-family: 'Merriweather';
         font-style: normal;
         font-weight: 700;
         font-size: 48px;
         line-height: 66px;
      }
   }
}
</style>