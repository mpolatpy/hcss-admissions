import React from 'react';
import { useFormikContext } from 'formik';
import { Grid, Typography } from '@mui/material';


export default function ReviewApplication() {
  const { values: formValues } = useFormikContext();

  return (
    <>
      <Typography variant="h6" gutterBottom>
        Application Summary
      </Typography>
      <Grid container spacing={2}>
          <button type="button" onClick={() => console.log(formValues)}>Form Values</button>
      </Grid>
    </>
  );
}