import  cuisines from './data/cuisines.json' 

const fetch = (mockData : object, time = 0) => {
    return new Promise((resolve) =>{
        setTimeout(() => {
            resolve(mockData)
        }, time)
    })
}

export default{
    fetchCuisines (){
        return fetch(cuisines, 1000);
    }
}