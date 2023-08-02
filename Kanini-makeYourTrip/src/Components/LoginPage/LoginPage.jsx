import React from 'react'
import loginImage from '../../assets/images/login.png'
import myavatar from '../../assets/images/Login-logo.png'
import './LoginPage.css'
const LoginPage = () => {
  return (
    <div className="loginbody">
      <div class="logincontainer">
        <div class="img">
          <img src={loginImage} alt="" />
        </div>
        <div class="login-container">
          <form>
            <div class="img-avatar">
              <img src={myavatar} alt="" />
            </div>
            <h2>log in</h2>
            <div class="input-div one focus">
              <div class="i">
                <i class="fa fa-user" aria-hidden="true"></i>
              </div>
              <div>
                <input
                  type="text"
                  formControlName="username"
                  name="username"
                  className="input"
                  placeholder="Username"
                />
              </div>
            </div>
            <div class="msg error">
              <span>Username is required</span>
            </div>
            <div class="input-div focus two">
              <div class="i">
                <i class="fa fa-lock" aria-hidden="true"></i>
              </div>
              <div>
                <input
                  type="password"
                  formControlName="password"
                  name="password"
                  class="input"
                  placeholder="Password"
                />
              </div>
            </div>
            &nbsp;
            <div class="msg error">
              <span>Password is required</span>
            </div>
            <div>
              <div>
                <input type="submit" class="btn" value="Login" id="btnSubmit" />
              </div>
              <div class="msg light">{/* {{ statusmessage }} */}</div>
            </div>
            <div class="signup">
              <h4>Don't have an account?&nbsp;&nbsp;</h4>
              <a>Sign Up</a>
            </div>
          </form>
        </div>
      </div>
    </div>
  )
}

export default LoginPage
