// This is the script that will fetch and display the counter.
// window.addEventListener('DOMContentLoaded', (event) => {
//     getVisitCount();
// });

const functionApiUrl = 'https://getresicounter.azurewebsites.net/api/GetResumeCounter?code=cre70RVuFmsEz7h66Ea2tpgELPj0ucJUXNZ7dFXRQ9j3i6JfFz2nyQ=='
const localfunctionApi = 'http://localhost:7071/api/GetResumeCounter'; 

const getVisitCount = () => {
    let count = 30;
    fetch(functionApiUrl).then(response => {
        return response.json()
    }).then(response =>{
        console.log("Website called function API.");
        count = response.count;
        document.getElementById("counter").innerText = count;
    }).catch(function(error) {
        console.log(error);
      });
    return count;
}

getVisitCount();