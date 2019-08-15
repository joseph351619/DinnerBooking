<template>
    <v-container grid-list-xl pt-4 px-1>
        <v-layout wrap row  v-for="cuisine in cuisines" :key="cuisine.id">
            <cuisine 
                :id="cuisine.id"
                :count="cuisine.count"
                :name="cuisine.name"
                :description="cuisine.description"
                :price="cuisine.price">
            </cuisine>
        </v-layout>
    </v-container>
</template>
<script>
import Cuisine from "@/components/Cuisine";
export default {
    prop:{
        categoryId:{
            type:Number
        }
    },
    data: function(){
        return {
            cuisines: []
        }
    },
    components:{
        Cuisine: Cuisine
    },
    computed:{
        cuisines (){
            let that = this;
            return this.$store.state.cuisines.filter(function(item, index, array){
                return item.categoryId === that.categoryId;
            })
        }
    }
}
</script>