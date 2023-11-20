<template>
  <div>
    <div class="header">
      <section class="header-background">
        <img src="@/assets/T(2).png" alt="Header Image" />
      </section>
    </div>
    <div class="container">
      <section class="password-experience">
        <h1>Tere tulemast tuutoriplatvormile!</h1>
        <div class="button-container">
          <router-link to="/tutors" class="btn get-started">Alusta</router-link>
          <p>või registreeri end</p>
          <router-link to="/newtutor" class="btn get-started">Tuutor</router-link>
          <router-link to="/newstudent" class="btn get-started">Tudeng</router-link>
        </div>
      </section>
      <section class="cloud-security">
        <p>
          Meie platvorm on suunatud kõrg- ja kutsehariduse üliõpilastele, ja selle peamine eesmärk on aidata neil ülikooli tööga. Inimesed saavad igal ajal abi küsida ja saada personaalset nõu nii veebis kui ka offline režiimis.
        </p>
        <div class="features">
          <div class="feature">
            <h3>100+</h3>
            <p>Ained</p>
          </div>
          <div class="feature">
            <h3>24/7</h3>
            <p>Abi</p>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>

<style scoped>
.container {
  font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
  max-width: 1080px;
  margin: 40px auto;
  padding: 77px 40px;
  background-color: #ffdd3c;
  border-radius: 14px;
  box-shadow: 0 4px 20px rgba(0, 0, 0, 0.1);
}

.header-background {
  background-size: cover;
  height: 90vh;
}

.password-experience,
.cloud-security {
  text-align: center;
  margin-bottom: 70px;
  font-weight: 1000;
}

.password-experience h1 {
  font-size: 34px;
  margin-bottom: 30px;
}

.button-container {
display: flex;
gap: 20px;
text-align: center;
justify-content: center;
align-items: row;
margin-top: 20px;
flex-direction: row; 
}

.btn {
  padding: 10px 32px;
  border: none;
  border-radius: 8px;
  cursor: pointer;
  font-size: 18px;
  transition: all 0.2s ease-in-out;
}

.get-started {
  background-color: #5271ff;
  color: #fff;
}

.learn-more {
  background-color: #5271ff;
  color: #fff;
}

.cloud-security h2 {
  font-size: 28px;
  margin-bottom: 25px;
}

.features {
  display: flex;
  gap: 50px;
  justify-content: center;
  margin-top: 50px;
}

.feature {
  flex-basis: 32%;
  padding: 40px;
  background-color: #f7f7f7;
  border-radius: 10px;
  box-shadow: 0 4px 16px rgba(0, 0, 0, 0.08);
}

.feature h3 {
  font-size: 40px;
  margin-bottom: 20px;
}

.feature p {
  font-size: 20px;
}
.password-experience,
.cloud-security {
  width: 100%;
}
</style>

<script lang="ts">
export default {};
</script>
