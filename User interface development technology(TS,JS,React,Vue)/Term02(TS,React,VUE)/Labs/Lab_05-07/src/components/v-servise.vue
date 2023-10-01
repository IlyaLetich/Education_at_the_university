<template>
    <div :class="$style.roditel" id = "roditel">
        <div :class="$style.textItem1">
        Наши услуги
    </div>
    <div :class="$style.textItem2">
        Мы специализируемся
    </div>
    <div :class="$style.wrapperSer">
        <div :class="$style.servise">
            <v_service_item
                v-for="item in service_Data"
                :key="item.id"
                :service_Data_Item = "item"
            />
        </div>
    </div>
    </div>
</template>
    
<script>


import vServiceItem from './v-service-item.vue'
    
export default {
    name: "v-service",
    components: {
        v_service_item : vServiceItem
    },
    props: {
        service_Data: {
          type: Array,
          default: () => []
        }
    },
    data(){
        return{
        }
      },
    methods: {
        
    },
}

</script>
    
<style module >
.roditel{
    background-color: #EBEBEB;
}
.wrapperSer{
    margin-left: 220px;
    padding-bottom: 40px;
}
.service{
  display: flex;
  justify-content: flex-start;
  flex-wrap: wrap;
}
.textItem1{
    padding-top: 100px;
    width: 350px;
    height: 23px;
    margin-left: 220px;
    top: 2966px;
    font-family: 'Lato';
    font-style: normal;
    font-weight: 900;
    font-size: 24px;
    line-height: 33px;
    color: #BDBDBD;
}
.textItem2{
    padding-top: 40px;
    height: 47px;
    margin-left: 220px;
    padding-bottom: 70px;
    font-family: 'Merriweather';
    font-style: normal;
    font-weight: 900;
    font-size: 48px;
    color: #333333;
    margin-bottom: 30px;
  }
</style>