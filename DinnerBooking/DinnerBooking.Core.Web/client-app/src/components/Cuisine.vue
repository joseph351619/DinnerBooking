<template>
    <v-card flex xs4 >
        <v-img
            class="theme--light"
            height="400px"
            src="url('http://lorempixel.com/200/200/food/{{id}}')"
            >
        <v-card-title class="align-top fill-height">
            仲有 {{count}} 份
        </v-card-title>
        </v-img>
        <v-card-title>
            ${{price}}
        </v-card-title>
        <v-card-title>
            {{name}}
        </v-card-title>
        <v-card-text>
            {{description}}
        </v-card-text>
        <v-card-action>
            <v-btn text icon xs12 color="primary" @click="pickOne">
                <v-icon>favorite</v-icon>             買
            </v-btn>
        </v-card-action>
    </v-card>
</template>

<script>
export default {
    props:{
        id:{
            type:Number
        },
        count:{
            type:Number
        },
        name:{
            type:String,
            default:'title'
        },
        description:{
            type:String,
            default:'Description'
        },
        price:{
            type:Number
        }
    },
    methods:{
        pickOne: function(){

        }
    }
}
</script>