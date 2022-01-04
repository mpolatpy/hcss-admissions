import React from 'react';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import CustomTextField from '../../CustomTextField';

const ParentDetails = () => (
    <Grid container rowSpacing={2} spacing={2} mt={1}>
      <Grid item xs={12} sm={12} mt={1}>
          <Typography variant="h5" color="teal">Parent Information</Typography>
      </Grid>
      <Grid item xs={12} sm={12} mt={1}>
          <Typography variant="h6" color="teal">Primary Parent</Typography>
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField
            label="Primary Parent Name" 
            name="primaryParentName" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField
            label="Primary Parent Relation to Student" 
            name="primaryParentRelationship" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField
            label="Primary Parent Email" 
            name="primaryParentEmail" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField
            label="Primary Parent Phone" 
            name="primaryParentPhone" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} sm={12} mt={1}>
          <Typography variant="h6" color="teal">Secondary Parent</Typography>
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField
            label="Secondary Parent Name" 
            name="secondaryParentName" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField
            label="Secondary Parent Relation to Student" 
            name="secondaryParentRelationship" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField
            label="Secondary Parent Email" 
            name="secondaryParentEmail" 
            variant="outlined"
        />
      </Grid>
      <Grid item xs={12} md={6}>
        <CustomTextField
            label="Secondary Parent Phone" 
            name="secondaryParentPhone" 
            variant="outlined"
        />
      </Grid>
    </Grid>
);

export default ParentDetails;
