import React from 'react';
import { useFormikContext } from 'formik';
import { Grid, Typography } from '@mui/material';
import { Application } from '../../../models/ApplicationFormModels';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import { observer } from 'mobx-react-lite';
import { useStore } from '../../../stores/store';
import CustomCheckBox from '../../CustomCheckBox';


const ReviewApplication = () => {
  const { values: formValues } = useFormikContext<Application>();
  const { commonStore } = useStore();
  const { schools, schoolYears } = commonStore;
  const school = schools.find(x => x.id == formValues.schoolId)?.schoolName;
  const schoolYear = schoolYears.find(x => x.id == formValues.schoolYearId)?.formLabel;
  const dateOfBirth = new Date(formValues.dob!).toLocaleDateString();

  return (
    <Grid container rowSpacing={2} spacing={2} mt={1}>
      <Grid item xs={12} sm={12} mt={1}>
        <TableContainer>
          <Table aria-label="sticky table">
            <TableHead>
              <TableRow>
                <TableCell align="center" colSpan={2}>
                  <Typography variant="h5" color="teal">Application Summary</Typography>
                </TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              <TableRow>
                <TableCell colSpan={2}>
                  <Typography variant="h6" color="teal">Application Details</Typography>
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell>To which year are you applying?</TableCell>
                <TableCell>{schoolYear}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>To which grade are you applying?</TableCell>
                <TableCell>Grade {formValues.grade}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>To which school(s) are you applying? </TableCell>
                <TableCell>{school}</TableCell>
              </TableRow>

              <TableRow>
                <TableCell colSpan={2}>
                  <Typography variant="h6" color="teal">Student Information</Typography>
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell>First Name</TableCell>
                <TableCell>{formValues.firstName}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Middle Name</TableCell>
                <TableCell>{formValues.middleName}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>LastName</TableCell>
                <TableCell>{formValues.lastName}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Date of Birth</TableCell>
                <TableCell>{dateOfBirth}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Gender</TableCell>
                <TableCell>{formValues.gender}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Current School</TableCell>
                <TableCell>{formValues.currentSchool}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Current Grade</TableCell>
                <TableCell>{formValues.currentGrade}</TableCell>
              </TableRow>

              <TableRow>
                <TableCell colSpan={2}>
                  <Typography variant="h6" color="teal">Address</Typography>
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Home Address</TableCell>
                <TableCell>{formValues.streetAddress}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>City</TableCell>
                <TableCell>{formValues.city}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>State</TableCell>
                <TableCell>{formValues.state}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Zipcode</TableCell>
                <TableCell>{formValues.zipcode}</TableCell>
              </TableRow>


              <TableRow>
                <TableCell colSpan={2}>
                  <Typography variant="h6" color="teal">Primary Parent Information</Typography>
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>{formValues.primaryParentName}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Relationship</TableCell>
                <TableCell>{formValues.primaryParentRelationship}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Email</TableCell>
                <TableCell>{formValues.primaryParentEmail}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Phone Number</TableCell>
                <TableCell>{formValues.primaryParentPhoneNumber}</TableCell>
              </TableRow>

              <TableRow>
                <TableCell colSpan={2}>
                  <Typography variant="h6" color="teal">Secondary Parent Information</Typography>
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Name</TableCell>
                <TableCell>{formValues.secondaryParentName}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Relationship</TableCell>
                <TableCell>{formValues.secondaryParentRelationship}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Email</TableCell>
                <TableCell>{formValues.secondaryParentEmail}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Phone Number</TableCell>
                <TableCell>{formValues.secondaryParentPhoneNumber}</TableCell>
              </TableRow>

              <TableRow>
                <TableCell colSpan={2}>
                  <Typography variant="h6" color="teal">Other Information</Typography>
                </TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Does the applicant have a sibling* who currently attends HCSS?</TableCell>
                <TableCell>{formValues.hasSibling ? "Yes" : "No"}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Which school does the sibling currently attend?</TableCell>
                <TableCell>{formValues.siblingSchool}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Sibling Full Name</TableCell>
                <TableCell>{formValues.siblingName}</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>How did you hear about HCSS-East and/or HCSS-West?</TableCell>
                <TableCell>{formValues.howDidYouHear}</TableCell>
              </TableRow>
            </TableBody>
          </Table>
        </TableContainer>
      </Grid>
      <Grid item xs={12} sm={12} mt={1}>
        <Typography variant="h6">Non-Discrimination Statement</Typography>
        <Typography variant="caption">
          In accordance with M.G.L. c. 76, s. 5, Hampden Charter School of Science shall not discriminate nor tolerates harassment based on race, color, national origin, creed, sex, ethnicity, gender identity, sexual orientation, mental or physical disability, age, ancestry, athletic performance, special need, proficiency in the English language or a foreign language, or prior academic achievement. Hampden Charter School of Science has a zero tolerance for harassment based on these areas.
          A school may not require any action by a student or family (such as an admissions test, interview, essay, attendance at an information session, etc.) in order for an applicant to either receive or submit an application for admission to that school.
        </Typography>
      </Grid>
      <Grid item xs={12} sm={12} mt={1}>
        <Typography variant="h6">Certification Statement</Typography>
        <Typography variant="caption">
          We hereby certify that, to the best of my/our knowledge and belief, the answers to the foregoing questions and statements made by me/us in this application are complete and accurate. I/We understand that any false information or misrepresentations of facts may result in rejection of this application or future dismissal of the applicant.
        </Typography>
      </Grid>
      <Grid item xs={12} sm={12}>
        <CustomCheckBox
          name="agreeToTerms"
          label="I agree"
        />
      </Grid>
    </Grid>
  );
}

export default observer(ReviewApplication);