import React from 'react';
import RadioButtons from '../../RadioButtons';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';

const ApplicationDetails = () => (
    <Grid container spacing={1} mt={1}>
        <Grid item xs={12} sm={12} mt={1}>
            <Typography variant="h5" color="teal">Application Details</Typography>
        </Grid>
        <Grid item xs={12} sm={12} mt={2}>
            <RadioButtons
                options={['21-22', '22-23']}
                labels={['21-22 (Current School Year)', '22-23 (Upcoming School Year)']}
                legend="To which year are you applying?"
                name="schoolYear"
            />
        </Grid>
        <Grid item xs={12} sm={12} mt={2}>
            <RadioButtons
                options={[6, 7, 8, 9, 10]}
                labels={['Grade 6', 'Grade 7', 'Grade 8', 'Grade 9', 'Grade 10']}
                legend="To which grade are you applying? "
                name="grade"
            />
        </Grid>
        <Grid item xs={12} sm={12} mt={2}>
            <RadioButtons
                options={['Both Schools', 'HCSS East', 'HCSS West']}
                labels={['Both Schools', 'HCSS East', 'HCSS West']}
                legend="To which school(s) are you applying? "
                name="school"
            />
        </Grid>
    </Grid>
);

export default ApplicationDetails;