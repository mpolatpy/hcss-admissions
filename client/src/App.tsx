import React, { useEffect } from 'react';
import './initial-files/App.css';
import { Routes, Route } from "react-router-dom";
import NavBar from './components/NavBar';
import HomePage from './pages/HomePage';
import CssBaseline from '@mui/material/CssBaseline';
import Container from '@mui/material/Container';
import Footer from './components/Footer';
import ApplicationForm from './pages/ApplicationForm';
import { observer } from 'mobx-react-lite';
import {useStore} from './stores/store';
import Loader from './components/Loader';

function App() {
  const {commonStore } = useStore();
  const {appLoaded, loadInitialData} = commonStore;

  useEffect(() => {
    loadInitialData();
  },[loadInitialData]);

  if(!appLoaded){
    return (
      <Loader 
        loading={!appLoaded} 
        content='Loading...' 
      />
    )
  }

  return (
    <>
      <CssBaseline />
      <NavBar />
      <Container maxWidth="xl">
        <Routes>
          <Route path ="/" element={<HomePage />} />
          <Route path="/application-form" element={<ApplicationForm/>} />
        </Routes>
      </Container>
      <Footer />
    </>
  );
}

export default observer(App);
