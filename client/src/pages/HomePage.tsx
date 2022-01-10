import React from 'react';
import {Link} from 'react-router-dom';
import Box from '@mui/material/Box';
import Grid from '@mui/material/Grid'
import { Button, Card, CardMedia, Divider, Typography } from '@mui/material';

const HomePage = () => {

    return (
        <Grid container mt={2} style={{ display: 'flex', alignItems: 'center', justifyContent: 'center' }}>
            {/* <Grid item sm={12} md={12} style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                <Button size="large" variant="contained" color="info">Apply Now</Button>
            </Grid> */}
            <Grid item md={6} sm={12} p={3}>
                <Card variant="outlined" style={{ padding: '20px', backgroundColor: '#EAEAEA'}}>
                    <CardMedia
                        component="img"
                        image='https://hampdencharter.org/wp-content/uploads/2019/10/slide2.jpg'
                        height="200"
                    />
                    <Typography variant="caption" mt={3}>
                        HCSS-East and HCSS-West do not discriminate against students on the basis of race, color, national origin, creed or religion, sex, gender identity, ethnicity, sexual orientation, mental or physical disability, age, ancestry, athletic performance, special need, proficiency in the English language or in a foreign language, or prior academic achievement when recruiting or admitting students.HCSS-East and HCSS-West do not set admissions criteria that are intended to discriminate or that have the effect of discrimination based upon any of these characteristics. The process of enrollment will be conducted according to the laws and the regulations of Massachusetts (M.G.L. c. 71, § 89; 603 CMR 1.05).
                    </Typography>
                </Card>
            </Grid>
            <Grid item md={6} sm={12} p={3}>
                <Card variant="outlined" 
                style={{ 
                    padding: '20px', 
                    backgroundColor: 'inherit',
                    minHeight: '60vh'
                    }}
                >
                    <Typography variant="body1" mb={2} paragraph>
                        <strong>Hampden Charter School of Science- East (HCSS-East)</strong> accepts applications from students who reside in Massachusetts, with preference given to students who reside within Chicopee, Ludlow, Springfield, and West Springfield districts of Massachusetts. HCSS-East serves students in grades six through twelve and accepts applications for students in all available in grades six through ten each year. G.L., c. 71, §89 (m).
                    </Typography>
                    <Typography variant="body1" paragraph>
                        <strong>Hampden Charter School of Science- West (HCSS-West)</strong> accepts applications from students who reside in Massachusetts, with preference given to students who reside within Agawam, Westfield, Holyoke, and West Springfield districts of Massachusetts. HCSS-West serves students in grades six through twelve and accepts applications for students in all available in grades six through ten each year. G.L., c. 71, §89 (m).
                    </Typography>
                </Card>
            </Grid>
            <Grid item sm={12} md={12} style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
                <Button 
                    size="large" 
                    variant="contained" 
                    component={Link} 
                    to="/application-form" 
                    color="info"
                >
                    Apply Now
                </Button>
            </Grid>
            <Grid item sm={12} md={12} my={2} >
                <Divider/>
                <Box sx={{textAlign: 'center'}}>
                    <Typography my={2} variant='h5'>Applications in Other Languages</Typography>
                </Box>
                <Box sx={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'space-between', alignItems: 'center' }}>
                    <Button size="large" variant="outlined">English</Button>
                    <Button size="large" variant="outlined">Spanish</Button>
                    <Button size="large" variant="outlined">Arabic</Button>
                    <Button size="large" variant="outlined">Chinese</Button>
                    <Button size="large" variant="outlined">Russian</Button>
                    <Button size="large" variant="outlined">Nepali</Button>
                    <Button size="large" variant="outlined">Turkish</Button>
                    <Button size="large" variant="outlined">Portugese</Button>
                </Box>
            </Grid>
        </Grid>
    );
}

export default HomePage;