import React from 'react';
import Grid from '@mui/material/Grid';
// import Paper from '@mui/material/Paper';
import Box from '@mui/material/Box';
import SteppedForm from '../components/application-form/SteppedForm';
import { observer } from 'mobx-react-lite';

const ApplicationForm = () => {

    return (
        <Grid container>
            <Grid item xs={0} sm={1} md={2} lg={3}></Grid>
            <Grid item xs={12} sm={10} md={8} lg={6}>
                <Box sx={{ backgroundColor: 'inherit', padding: '30px', margin: '20px 0 20px'}} >
                    <SteppedForm />
                </Box>
            </Grid>
            <Grid item xs={0} sm={1} md={2} lg={3}></Grid>
        </Grid>
    )
};

export default observer(ApplicationForm);