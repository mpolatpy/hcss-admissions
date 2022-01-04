import React from 'react';
import { useFormikContext } from 'formik';
import Grid from '@mui/material/Grid';
import Typography from '@mui/material/Typography';
import CustomTextField from '../../CustomTextField';
import RadioButtons from '../../RadioButtons';
import { howDidYouHearOptions } from '../formOptions';
import { Application } from '../../../models/ApplicationFormModels';

const OtherDetails = () => {
    const { values } = useFormikContext<Application>();
    const { hasSibling } = values;

    return (
        <Grid container rowSpacing={2} spacing={2} mt={1}>
            <Grid item xs={12} sm={12} mt={1}>
                <Typography variant="h5" color="teal">Complete the Application!</Typography>
            </Grid>
            <Grid item xs={12} sm={12} >
                <Typography variant="h6" color="teal">Sibling Information</Typography>
            </Grid>
            <Grid item xs={12} sm={12} >
                <RadioButtons
                    options={[true, false]}
                    labels={['Yes', 'No']}
                    legend="Does the applicant have a sibling* who currently attends HCSS?"
                    name="hasSibling"
                    description='*Sibling preference for admission is only applies to students who share a common parent through birth or legal adoption. Students must provide documentation (i.e.: birth certificate, legal records) to receive preference. Sibling preference will only be applied for the campus which the sibling attends.'
                />
            </Grid>
            {
                hasSibling &&
                (
                    <>
                        <Grid item xs={12} sm={12} >
                            <Typography variant="body2" color="teal">If yes, please fill out the next two fields.</Typography>
                        </Grid>
                        <Grid item xs={12} sm={12}>
                            <RadioButtons
                                options={['HCSS East', 'HCSS West']}
                                labels={['HCSS East', 'HCSS West']}
                                legend="Which school does the sibling currently attend?"
                                name="siblingSchool"
                            />
                        </Grid>
                        <Grid item xs={12} sm={12}>
                            <CustomTextField
                                name="siblingName"
                                label="Sibling Full Name"
                                variant="outlined"
                            />
                        </Grid>
                    </>
                )}
            <Grid item xs={12} sm={12} mt={1}>
                <RadioButtons
                    options={howDidYouHearOptions}
                    labels={howDidYouHearOptions}
                    legend="How did you hear about HCSS-East and/or HCSS-West?"
                    name="howDidYouHear"
                />
            </Grid>
        </Grid>
    );
}
export default OtherDetails;
