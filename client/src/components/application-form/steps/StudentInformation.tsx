import React from 'react';
import CustomTextField from '../../CustomTextField';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import CustomDatePicker from '../../CustomDatePicker';
import CustomSelect from '../../CustomSelect';

const StudentInfo = () => (
  <Grid container rowSpacing={2} spacing={2} mt={1}>
      <Grid item xs={12} sm={12} mt={1}>
          <Typography variant="h5" color="teal">Student Information</Typography>
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField 
            label="First Name" 
            name="firstName" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField 
            label="Last Name" 
            name="lastName" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={4}>
        <CustomTextField 
            label="Middle Name" 
            name="middleName" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={4}>
        <CustomDatePicker
          label="Date of Birth"
          variant='outlined'
          name="dob"
        />
      </Grid>
      <Grid item xs={12} md={4}>
        <CustomSelect 
            label="Gender" 
            name="gender" 
            options={['Female','Male']}
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={4}>
        <CustomSelect 
            label="Current Grade"
            name="currentGrade" 
            options={['5', '6', '7', '8', '9']}
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={8}>
        <CustomTextField 
            label="Current School" 
            name="currentSchool" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} sm={12} mt={1}>
          <Typography variant="h6" color="teal">Address</Typography>
      </Grid>
      <Grid item xs={12} md={12}>
        <CustomTextField 
            label="Home Address" 
            name="streetAddress" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField 
            label="City" 
            name="city" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={3}>
        <CustomSelect 
            label="State" 
            name="state" 
            options={['MA', 'Other']}
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={3}>
        <CustomTextField 
            label="Zip Code" 
            name="zipcode" 
            variant="outlined"
        />
      </Grid>
  </Grid>
);

export default StudentInfo;