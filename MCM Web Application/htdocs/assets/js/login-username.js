'use strict'
let username;
let dataToSend;
let accountData; // an array to store account data queried from MySQL DB

// Login button behaviour
document.querySelector('#login-btn').addEventListener('click',  function(e) {
  debugger
    username = document.querySelector('#usr').value;

    // When user did not fill up the username and password.
    if (!username) {
        return;
    } 
     // When user fill up the username and/or password.
     else {
       const request = new XMLHttpRequest();
       request.open('GET', "login-username-validate.php?username="+username, true);
       request.send();
       request.addEventListener('readystatechange', function(event) {
           if (event.target.readyState === 4 && event.target.status === 200) {
             debugger
                accountData = JSON.parse(event.target.responseText); 

              // When username credentials is correct
              // Convert into JSON and store temp data to local web storage for use later on.
              if (accountData[0] === true) {
                if( accountData[3] === "System Administrator" || accountData[3] === "Assistant Manager" || accountData[3] === "Operational Manager" || accountData[3] === "Owner") {
                  document.querySelector('#usr').value = '';
                  // inform user that they have entered the incorrect credentials and show the number of attempts left.
                  window.alert(`Username entered is incorrect. Please check again.`);
                  return;
                }
                else {
                let JSONData  = JSON.stringify(accountData);
                localStorage.setItem('accountData', JSONData);
                window.location.assign(`login-password.php`);
                }
              }

              // When username credentials is incorrect
              else if (accountData[0] === false) {
                document.querySelector('#usr').value = '';

                // inform user that they have entered the incorrect credentials and show the number of attempts left.
                window.alert(`Username entered is incorrect. Please check again.`);
                return;
              }
           }
       })
    }
})
