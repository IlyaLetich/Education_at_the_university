<template>
   <div :class="$style.container">
      <div :class="$style.osnova">
         <div v-for="item in GetDataInPlate" :key="item.id">
            <div :class="$style.tile">
               <h1 :class="$style.textElement">{{ item.num }}</h1>
               <p :class="$style.textDeal"> {{ item.text }}</p>
               <a href="#" :class="$style.textLink"> {{ item.link }} </a>
            </div>
         </div>
      </div>
   </div>
</template>

<script>
export default {
   props: {
      GetDataInPlate: {
         type: Array,
         default: () => [],
      },
   },
   methods: {
   }
}
</script>

<style lang="scss" module>
.osnova {
   padding-bottom: 100px;
   display: grid;
   grid-template-columns: 1fr 1fr;
   grid-column-gap: 30px;
   grid-row-gap: 30px;

}

.tile {
   height: 255px;
   width: 255px;
   background-color: #EBEBEB;
   padding-left: 40px;
}

.tile:hover {
   background-color: #005FA3;

   h1.textElement {
      color: #ffffff;

   }

   .textDeal {
      color: #ffffff;
   }

   .textLink {
      text-decoration-line: underline;
      color: #ffffff;
   }
}

h1.textElement {
   margin: 0px;
   font-family: 'Lato';
   font-style: normal;
   font-weight: 900;
   font-size: 55px;
   line-height: 66px;
   letter-spacing: 0.1em;
   text-transform: uppercase;
   padding-top: 25px;
   margin-bottom: 55px;
   color: #000000;
   height: 54px;
   width: 74px;
}

.textDeal {
   width: 107px;
   font-family: 'Lato';
   font-style: normal;
   font-weight: 700;
   font-size: 14px;
   line-height: 18px;
   padding-bottom: 22px;
   color: #000000;
}

.textLink {
   font-family: 'Lato';
   font-style: normal;
   font-weight: 700;
   font-size: 14px;
   line-height: 17px;
   text-decoration-line: underline;
   color: #005FA3;
   padding-bottom: 13px;
}
</style>