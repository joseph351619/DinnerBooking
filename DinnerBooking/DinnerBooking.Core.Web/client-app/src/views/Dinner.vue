<template>
    <v-container>
        <v-layout>
            <v-flex xs12>
                <v-img url="https://picsum.photos/id/163/1280/480">
                    <v-toolbar>
                        <v-btn icon>
                            <v-icon>more_vert</v-icon>
                        </v-btn>
                    </v-toolbar>
                </v-img>
            </v-flex>
        </v-layout>
        <v-layout>
            <v-tabs
             grow 
             background-color=""
             dark
             >
                <v-tabs-slider color="orange"></v-tabs-slider>
                <v-tab>是日精選</v-tab>
                <v-tab>廚師推介</v-tab>
                <v-tab>特價推廣</v-tab>
            </v-tabs>
            <v-tabs-items v-model="tab">
                <v-tab-item>
                    <CuisineTab
                        :categoryId=1>
                    </CuisineTab>
                </v-tab-item>
                <v-tab-item>
                    <CuisineTab
                        :categoryId=2>
                    </CuisineTab>
                </v-tab-item>
                <v-tab-item>
                    <CuisineTab
                        :categoryId=3>
                    </CuisineTab>
                </v-tab-item>
            </v-tabs-items>
        </v-layout>
    </v-container>
</template>
<script>
import CuisineTab from '../components/CuisineTab'
export default {
    components:{
        CuisineTab : CuisineTab
    }
}
</script>