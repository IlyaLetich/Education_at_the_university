<template>
   <div :class="$style.base" id="kiesy">
      <div :class="$style.base__content">
         <div :class="$style.content__textAbout">
            <div :class="$style.textAbout__aboutMy">
               <p :class="$style.sa">О нас </p>
            </div>
            <div :class="$style.textAbout__company">
               <p :class="$style.sa2">Компания</p>
               <p :class="$style.sa2sin">ИвановПром</p>
            </div>
            <div :class="$style.textAbout__mainText">
               <p :class="$style.sa3">Lorem Ipsum - это текст-"рыба", часто используемый в печати и вэб-дизайне. Lorem Ipsum
                  является стандартной "рыбой" для текстов на латинице с начала XVI века. В то время некий безымянный
                  печатник создал большую коллекцию размеров и форм шрифтов, используя Lorem Ipsum для распечатки образцов.
                  Lorem Ipsum не только успешно пережил без заметных изменений пять веков, но и перешагнул в электронный
                  дизайн.</p>
            </div>
         </div>
         <div :class="$style.content__prosloika"></div>
         <div :class="$style.content__plate">
            <AboutPlate :GetDataInPlate="data" />
         </div>
      </div>
   </div>
</template>

<script>
import AboutPlate from './AboutPlate.vue'
export default {
   components: {
      AboutPlate
   },
   props: {
      data: {
         type: Array,
         default: () => [],
      },
      GetDataInPlate() {
         return {
            data: Array
         }
      }
   },
}
</script>

<style lang="scss" module>
.base {
   padding-top: 140px;
   background-color: #fff;
   padding-left: 220px;
   padding-right: 180px;

   &__content {
      display: grid;
      grid-template-columns: 1fr 100px 1fr;

      p.sa {
         height: 23px;
         font-family: 'Lato';
         font-style: normal;
         font-size: 21px;
         line-height: 33px;
         color: #BDBDBD;
      }

      p.sa2 {
         font-family: 'Merriweather';
         font-style: normal;
         font-weight: 900;
         font-size: 48px;
         margin-bottom: 0;
         color: #333333;
      }

      p.sa2sin {
         font-family: 'Merriweather';
         font-style: normal;
         font-weight: 900;
         font-size: 48px;
         line-height: 69px;
         color: #005FA3;
         margin-bottom: 46px;
      }

      p.sa3 {
         font-family: 'Lato';
         font-style: normal;
         font-weight: 300;
         font-size: 18px;
         line-height: 25px;

         color: #000000;
      }

      &__prosloika {
         grid-column-start: 2;
         grid-column-end: 3;
      }

      &__plate {
         grid-column-start: 3;
         grid-column-end: 4;
      }

   }

}
</style>