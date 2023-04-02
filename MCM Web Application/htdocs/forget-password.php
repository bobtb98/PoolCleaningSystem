<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, shrink-to-fit=no">
    <title>MCM Management System</title>
    <link rel="shortcut icon" type="image/png" href="assets\img\MCM Pool.png"/>
    <link rel="stylesheet" href="assets/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="assets/fonts/ionicons.min.css">
    <link rel="stylesheet" href="assets/css/Login-Form-Clean.css">
    <link rel="stylesheet" href="assets/css/Navigation-Clean.css">
    <link rel="stylesheet" href="assets/css/styles.css">
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
        <form action="/forget-password-process.php" method="post">
            <h2 class="sr-only">Login Form</h2>
            <img src="/assets/img/MCM Pool (Edited).png" >

            <div class="form-group">
                <?php
                session_start();
                $username = $_SESSION['Username'];
                // Username textbox
                echo "<input class='form-control' type='text' name='username' value='$username' style='font-weight: bold;' disabled='true'>";
                ?>
            </div>

            <label for="SecretQuestion">Secret Question</label>
            <div class="input-group mb-3">
                <?php
                    $secretQuestion = $_SESSION['SecretQuestion'];
                    // Secret Question selection list
                    echo "<select class='form-select' id='inputGroupSelect01'>";
                    echo "<option value='Q1'> $secretQuestion </option>";
                    echo "</select>";
                ?>
            </div>    

            <div class="form-group">
                <!-- Answer textbox -->
                <input class="form-control" type="text" name="SQAnswer" placeholder="Answer">
            </div>

            <div class="form-group">
                <!--Submit and Back Button-->
                <a href="/login-password.php" class="btn btn-primary btn-block">Back</a>
                <input class="btn btn-primary btn-block" type="submit"></button>
            </div>

            <?php
                if(isset($_SESSION['error'])){
                    if($_SESSION['error']=="Answer is incorrect."){
                        echo "<script>alert('Answer is incorrect. Please try again.') </script>";
                        unset($_SESSION['error']);
                    }
                }
            ?>
        </form>
    </div>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
</body>
</html>  