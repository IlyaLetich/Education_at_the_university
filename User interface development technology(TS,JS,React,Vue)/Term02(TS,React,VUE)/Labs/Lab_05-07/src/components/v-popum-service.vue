<template>
    <div :class="$style.popupService">
        <button :class="$style.butPop" @click="closePopup" style="z-index: 12;">X</button>
        <div :class="$style.descripton">
            <slot>
                
            </slot>
        </div>
    </div>
</template>
    
<script>
    
export default {
    name: "v-popup-service",
    props: {

    },
    data(){
        return{
        }
      },
    methods: {
        closePopup(){
            this.$emit('closePopup');
        }
    },
}

</script>
    
<style module>
    .popupService{
        z-index: 100;
        border: 1px solid black;
        position: fixed;
        top: 50px;
        left: 500px;
        width: 600px;
        box-shadow: 0 0 17px 0 #e7e7e7;
        height: 600px;
        background-color: white;
    }
    .butPop{
        width: 100px;
        height: 30px;
        border: 0;
        color: white;
        font-size: 24px;
        background-color: #007fda;
        float: right;
    }
    .descripton{
    }
</style>