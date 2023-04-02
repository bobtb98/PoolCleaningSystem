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
        <form action="/reset-password-process.php" method="post">
            <h2 class="sr-only">Login Form</h2>
            <img src="/assets/img/MCM Pool (Edited).png" >

            <!-- Username -->
            <div class="form-group">
                <?php
                session_start();
                $username = $_SESSION['Username'];
                echo "<input class='form-control' type='text' name='username' value='$username' style='font-weight: bold;' disabled='true'>";
                ?>
            </div>

            <!-- New Password -->
            <div class="form-group">
                <input class="form-control" type="text" name="newpassword" placeholder="New Password">
            </div>  

            <!-- Confirm New Password -->
            <div class="form-group">
                <input class="form-control" type="text" name="confirmnewpassword" placeholder="Confirm New Password">
            </div>

            <!--Submit Button-->
            <div class="form-group">
                <input class="btn btn-primary btn-block" type="submit"></button>
            </div>
            <?php
            if(isset($_SESSION['error1'])){
                if($_SESSION['error1']=="Both passwords must be the same. Please try again."){
                    echo "<script>alert('Both passwords must be the same. Please try again.') </script>";
                    unset($_SESSION['error1']);
				}
			}
            ?>
        </form>
    </div>
    <script src="assets/js/jquery.min.js"></script>
    <script src="assets/bootstrap/js/bootstrap.min.js"></script>
</body>

</html>  