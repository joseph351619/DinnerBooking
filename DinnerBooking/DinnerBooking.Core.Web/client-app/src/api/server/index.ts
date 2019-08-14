import axios from 'axios'
export default{
    fetchCuisines(){
        return axios
            .get('')
            .then(response => response.data)
    }
}