import Vue from 'vue';
import Vuex from 'vuex';
import {Cuisine} from './types';
import client from '@api-client';

Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    Cuisine: []
  },
  mutations: {
    setCuisines (state, cuisines){
      state.Cuisine = cuisines
    }
  },
  actions: {
    fetchCuisines ({commit}){
      return client
        .fetchCuisines()
        .then((cuisines : Cuisine ) => commit('setCuisines', cuisines))
    }
  }
});
