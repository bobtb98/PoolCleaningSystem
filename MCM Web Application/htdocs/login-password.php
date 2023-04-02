<!DOCTYPE html>
<html>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.0-beta3/dist/js/bootstrap.bundle.min.js" integrity="sha384-JEW9xMcG8R+pH31jmWH6WWP0WintQrMb4s7ZOdauHnUtxwoG2vI5DkLtS3qm9Ekf" crossorigin="anonymous"></script>

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>MCM Management System</title>
    <link rel="shortcut icon" type="image/png" href="assets\img\MCM Pool.png"/>
    <link rel="stylesheet" href="/assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="/assets/styles.css">
    <link rel="stylesheet" href="/assets/fonts/ionicons.min.css">
    <link rel="stylesheet" href="/assets/css/Login-Form-Clean.css">
    <link rel="stylesheet" href="/assets/css/Navigation-Clean.css">
</head>
<style>
    img{
        display: block;
        width: 68%;
        margin-bottom: 22px;
        margin-left: auto;
        margin-right: auto;
    }
</style>
<body>
    <div class="login-clean">
        <div class="container">
        <form method="">
                      
            <img src="/assets/img/MCM Pool (Edited).png" >

            <!-- Username textbox -->
            <div id="yourUsername" class="form-group"><input class="form-control"></div>

            <!-- Password textbox -->
            <input id="pwd" class="form-control" type="password" name="password" placeholder="Password">

            <div class="form-group">

                <!-- Back Button -->
                <input class="btn btn-primary btn-block" type="button" value='Back' onClick="document.location.href='/login-username.php'"/>
              
                <!-- Login Button -->
                <input id="login-btn2" class="btn btn-primary btn-block" type="button" value='Login'/>
                
                <!-- Forget password link -->
                <a class="forgot" href="forget-password.php">Forgot your password?</a>
            </div>
            
        </form>
        </div>
    </div>
    
    <script src="/assets/js/jquery.min.js"></script>
    <script src="/assets/bootstrap/js/bootstrap.min.js"></script>
    <script src="/assets/js/login-password.js"></script>
</body>

</html>