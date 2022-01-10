import React from 'react';
import RadioButtons from '../../RadioButtons';
import Typography from '@mui/material/Typography';
import Grid from '@mui/material/Grid';
import { useStore } from '../../../stores/store';
import { observer } from 'mobx-react-lite';
import { Link } from '@mui/material';

const ApplicationDetails = () => {

    const { commonStore } = useStore();
    const { schools, schoolYears } = commonStore;

    const schoolOptions = schools.map(s => s.id);
    const schoolLabels = schools.map(s => s.schoolName);
    const schoolYearOptions = schoolYears.map(s => s.id);
    const schoolYearLabels = schoolYears.map(s => s.formLabel);

    return (
        <Grid container spacing={1} mt={1}>
            <Grid item xs={12} sm={12} mt={1} sx={{textAlign: "center"}}>
                <Typography variant="h4" color="teal">HCSS Admission Form</Typography>
            </Grid>
            <Grid item xs={12} sm={12} mt={1}>
                <Typography variant="body2" mt={1}>
                    For the translation: <a href="https://goo.gl/1yH1qX" target="_blank">https://goo.gl/1yH1qX</a>
                </Typography>
                <Typography variant="body2" mt={1}>
                    DEAR PARENT(S) AND APPLICANT: Thank you for your interest in Hampden Charter School of Science East and/or West. Please fill out this application form completely. Information you supply may not be given to any other companies. Applications received unsigned or incomplete may not be considered for acceptance.
                </Typography>
                <Typography variant="body2" mt={1}>
                    The primary districts that our schools serve:
                </Typography>
                <Typography variant="body2" mt={1}>
                    HCSS-East: Chicopee, Ludlow, West Springfield, and Springfield
                </Typography>
                <Typography variant="body2" mt={1}>
                    HCSS-West: Agawam, Holyoke, West Springfield, Westfield
                </Typography>
                <Typography variant="body2" mt={1}>
                    Only students who live in these districts receive preference to that specific school and not to the other (unless you live in West Springfield—then you have preference to both schools). Any resident of Massachusetts, including students who may be homeless, are eligible to apply and to attend HCSS East or West.
                </Typography>
            </Grid>
            <Grid item xs={12} sm={12} mt={1}>
                <Typography variant="h5" color="teal">Application Details</Typography>
            </Grid>
            <Grid item xs={12} sm={12} mt={2}>
                <RadioButtons
                    options={schoolYearOptions}
                    labels={schoolYearLabels}
                    legend="To which year are you applying?"
                    name="schoolYearId"
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
                    options={schoolOptions}
                    labels={schoolLabels}
                    legend="To which school(s) are you applying? "
                    name="schoolId"
                />
            </Grid>
        </Grid>
    );
}

export default observer(ApplicationDetails);