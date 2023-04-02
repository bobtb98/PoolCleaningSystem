'use strict'
let password;
let dataToSend;
let isloginSuccesful;
let attempt = 4; // Variable to count number of login attempts.

// To retrieve data previously retrieved when inputting user's username.
// Extract JSON data from local web storage and convert into JS datatype
let JSONData = localStorage.getItem('accountData');
let accountData = JSON.parse(JSONData);
let accountStatus = accountData[2];
let username = accountData[1];

// To display/render User's username at login-username.php page
debugger 
const yourUsername = document.createElement('h6');
yourUsername.textContent = `${accountData[1]}`;
document.querySelector('#yourUsername').innerHTML = ''


// when the account user trying to login is not locked.
if (accountStatus === "Active") {
    // To display/render User's username at login-username.php page
    document.querySelector('#yourUsername').appendChild(yourUsername)

    // Login button behaviour
    document.querySelector('#login-btn2').addEventListener('click',  function(e) {
        debugger
        password = document.querySelector('#pwd').value;

            // When user did not fill up the username and password.
            if (!password) {
            return;
            } 

            // When user fill up the username and/or password.
            else {
            const request = new XMLHttpRequest();
            request.open('GET', "login-password-validate.php?username="+username+"&password="+password, true);
            request.send();
            request.addEventListener('readystatechange', function(event) {
              if (event.target.readyState === 4 && event.target.status === 200) {
                isloginSuccesful = JSON.parse(event.target.responseText); 
  
                // When login credentials is correct
                if (isloginSuccesful === true) {
                  location.assign('/homepage.php');
                }
                // When login credentials is incorrect
                else if (isloginSuccesful === false) {
                document.querySelector('#pwd').value = '';
                attempt-=1;

                // inform user that they have entered the incorrect credentials and show the number of attempts left.
                alert(`Password entered is incorrect.\nYou have ${attempt} attempt(s) left`);

                if( attempt == 0){ 
                    // update mySQL database, change the account who exceeds more than 3 tries, change acc status to 'locked'.
                    request.open('GET', "login-password-lockaccount.php?username="+username, true);
                    request.send();
                    request.addEventListener('readystatechange', function(event) {
                      if (event.target.readyState === 4 && event.target.status === 200) {
                        return;
                      }
                    })
                    document.getElementById("pwd").disabled = true;
                    window.alert(`Your account has been locked.\nPlease contact the system administrator.`);
                  }
                  return;
                }  
              }
            })
          }
    })
  }
// when the account user trying to login is locked.
else if (accountStatus === "Locked") {

    // To display/render User's username at login-username.php page
    document.querySelector('#yourUsername').appendChild(yourUsername)
    // debugger
        document.getElementById("pwd").disabled = true;
        alert(`Your account has been locked.\nPlease contact the system administrator.`);
  }